
using UnityEngine;
using DG.Tweening;
using TestTask.UI;
using System;
using TestTask.Gameplay;
using System.Linq;

namespace TestTask
{
    public class PlayerCharacter : MonoBehaviour
    {
        [Serializable]
        public class WealthSet
        {
            public EWealthType WealthType;
            public GameObject ActorModel;
        }

        private const float RotationDuration = 0.5f;

        [SerializeField] private WealthSet[] models;
        [SerializeField] private float lateralOffset;
        [SerializeField] private float sensitivity;
        [SerializeField] private Transform bodyPivot;
        [SerializeField] private Transform cameraPivot;
        [SerializeField] private HealthBar healthBarPrefab;
        [SerializeField] private float healthBarOffset;

        private float initialMaxHealth;
        private float currentHealth;
        private float maxHealth = 1f;
        private bool isDead;
        private HealthBar healthBar;
        private bool isStarted;
        private LevelPath path;
        private Vector3 nextPoint;
        private bool isPressed;
        private Vector3 lastInputPosition;
        private EWealthType wealthType;
        private Tween tween;

        public static PlayerCharacter Current { get; private set; }
        public Transform CameraPivot => cameraPivot;
        public float CurrentHealth => currentHealth;

        private void Awake()
        {
            Current = this;

            Global.LevelManager.OnLevelStarted += OnLevelStarted;
            EventBus.PickableObjectCollected.AddListener(OnPickableObjectCollected);
            EventBus.ChoiñeGate.AddListener(OnChoiñeGate);

            InitializeHealth();
        }

        private void OnDestroy()
        {
            if (Current == null)
            {
                Current = null;
            }

            Global.LevelManager.OnLevelStarted -= OnLevelStarted;
            EventBus.PickableObjectCollected.RemoveListener(OnPickableObjectCollected);
            EventBus.ChoiñeGate.RemoveListener(OnChoiñeGate);
        }

        private void Update()
        {
            UpdateMovement();
        }

        private void LateUpdate()
        {
            UpdateHealth();
        }

        public void StopMovement()
        {
            isStarted = false;
            tween.Kill();
        }

        private void OnLevelStarted()
        {
            path = Global.Level.Path;
            isStarted = true;
            MoveToNextPoint();
        }

        private void MoveToNextPoint()
        {
            nextPoint = path.GetNextPoint();
            var direction = (nextPoint - transform.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            transform.DORotateQuaternion(targetRotation, RotationDuration);
            var distance = Vector3.Distance(transform.position, nextPoint);
            var speed = 6f;
            var duration = distance / speed;
            tween = transform.DOMove(nextPoint, duration).SetEase(Ease.Linear).OnComplete(MoveToNextPoint);
        }

        private void InitializeHealth()
        {
            initialMaxHealth = Global.GeneralParameters.StartHealth;
            currentHealth = initialMaxHealth;

            CreateHealthBar();
        }

        public void Heal(float heal)
        {
            if (isDead)
            {
                return;
            }

            currentHealth += heal;
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            UpdateHealthValue();
        }

        public void DealDamage(float damage)
        {
            if (isDead)
            {
                return;
            }

            if (damage <= 0f)
            {
                return;
            }

            currentHealth -= damage;
            if (currentHealth <= 0f)
            {
                currentHealth = 0f;
                Die();
            }

            UpdateHealthValue();
        }

        private void Die()
        {
            if (isDead)
            {
                return;
            }

            isDead = true;

            DestroyHealthBar();

            Global.GameController.GameOver();
        }

        private void DestroyHealthBar()
        {
            if (healthBar)
            {
                Destroy(healthBar.gameObject);
            }
        }

        private void UpdateHealthBarValue()
        {
            if (!healthBar)
            {
                return;
            }

            healthBar.SetHealth(currentHealth, maxHealth);
        }

        private void UpdateHealthValue()
        {
            var parameters = Global.WealthParameters;
            var set = parameters.WealthSets.FirstOrDefault(x => x.MinHealthValue <= currentHealth && x.MaxHealthValue >= currentHealth);
            if (wealthType != set.WealthType)
            {
                wealthType = set.WealthType;
                foreach (var model in models)
                {
                    model.ActorModel.SetActive(model.WealthType == wealthType);
                }
            }

            UpdateHealthBarValue();
        }

        private void UpdateHealth()
        {
            UpdateHealthBarPosition();
        }

        private void CreateHealthBar()
        {
            healthBar = Instantiate(healthBarPrefab, Global.UIController.ProgressBarContainer);

            UpdateHealthValue();
        }

        private void UpdateHealthBarPosition()
        {
            if (!healthBar)
            {
                return;
            }

            var screenPosition = Global.Camera.WorldToScreenPoint(bodyPivot.position);
            screenPosition.y += healthBarOffset * Constants.ScreenHeightAspect;
            healthBar.transform.position = screenPosition;
        }

        private void OnPickableObjectCollected(EPickableObjectType type)
        {
            var healthValue = 0f;
            switch (type)
            {
                case EPickableObjectType.Alcohol:
                    healthValue = Global.GeneralParameters.AlcoholHealthValue;
                    break;
                case EPickableObjectType.Money:
                    healthValue = Global.GeneralParameters.MoneyHealthValue;
                    break;
            }
            if (healthValue > 0f)
            {
                Heal(healthValue);
            }
            else
            {
                DealDamage(-healthValue);
            }
        }

        private void OnChoiñeGate(bool positive)
        {
            var healthValue = positive ? Global.GeneralParameters.PositiveGateBonusValue : Global.GeneralParameters.NegativeGateBonusValue;
            if (healthValue > 0f)
            {
                Heal(healthValue);
            }
            else
            {
                DealDamage(-healthValue);
            }
        }

        private void UpdateMovement()
        {
            if (!isStarted)
            {
                return;
            }

            if (isPressed)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    isPressed = false;
                }
                else
                {
                    var deltaX = (Input.mousePosition - lastInputPosition).x * Constants.ScreenWidthAspect;

                    var pos = bodyPivot.localPosition;
                    pos.x += deltaX * sensitivity;
                    if (pos.x < -lateralOffset)
                    {
                        pos.x = -lateralOffset;
                    }
                    else if (pos.x > lateralOffset)
                    {
                        pos.x = lateralOffset;
                    }
                    bodyPivot.localPosition = pos;

                    lastInputPosition = Input.mousePosition;
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    isPressed = true;
                    lastInputPosition = Input.mousePosition;
                }
            }
        }
    }
}
