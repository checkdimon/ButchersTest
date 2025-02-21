using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class Flags : MonoBehaviour
    {
        [SerializeField] private TriggerEnterEventInterceptor triggerEnterEventInterceptor;
        [SerializeField] private DOTweenAnimation[] flagssAnimation;

        private void Start()
        {
            triggerEnterEventInterceptor.TriggerEnter += OnDoorTriggerEnter;
        }

        private void OnDoorTriggerEnter()
        {
            Open();
        }

        private void Open()
        {
            foreach (var flagAnimation in flagssAnimation)
            {
                flagAnimation.DOPlay();
            }
        }
    }
}

