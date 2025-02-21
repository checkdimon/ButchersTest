using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private EWealthType wealthType;
        [SerializeField] private TriggerEnterEventInterceptor triggerEnterEventInterceptor;
        [SerializeField] private DOTweenAnimation[] doorsAnimation;

        private void Start()
        {
            triggerEnterEventInterceptor.TriggerEnter += OnDoorTriggerEnter;
        }

        private void OnDoorTriggerEnter()
        {
            var playerHealth = Global.PlayerCharacter.CurrentHealth;
            var set = Global.WealthParameters.WealthSets.FirstOrDefault(x => x.WealthType == wealthType);
            if (playerHealth >= set.MinHealthValue)
            {
                Open();
            }
            else
            {
                Global.GameController.LevelComplete();
            }
        }

        private void Open()
        {
            foreach (var doorAnimation in doorsAnimation)
            {
                doorAnimation.DOPlay();
            }
        }
    }
}

