
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace TestTask.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image mainImageSlider;
        [SerializeField] private Image backImageSlider;
        [SerializeField] private float speedUpdateSlider;

        private Tween fillAnimation;
        private bool isZeroValueAvailable;

        private void Awake()
        {
            backImageSlider.fillAmount = mainImageSlider.fillAmount = 1f;
        }

        private void Start()
        {
            transform.SetAsFirstSibling();
        }

        private void OnDestroy()
        {
            fillAnimation.Kill();
        }

        public void SetHealth(float currentValue, float maxValue)
        {
            if (fillAnimation != null)
            {
                fillAnimation.Complete();
            }

            var normalizedHP = currentValue / maxValue;
            var hpValue = (int)(isZeroValueAvailable ? Math.Floor(currentValue) : (currentValue > 1f ? Math.Ceiling(currentValue) : 1f));


            backImageSlider.fillAmount = mainImageSlider.fillAmount;
            mainImageSlider.fillAmount = normalizedHP;
            fillAnimation = backImageSlider.DOFillAmount(mainImageSlider.fillAmount, speedUpdateSlider);
            fillAnimation.OnComplete(() => fillAnimation = null);
        }

        public void AllowZeroValue()
        {
            isZeroValueAvailable = true;
        }
    }
}