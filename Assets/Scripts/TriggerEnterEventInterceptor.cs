using System;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class TriggerEnterEventInterceptor : MonoBehaviour
    {
        public event Action TriggerEnter;

        private void OnTriggerEnter(Collider other)
        {
            var actor = other.GetComponentInParent<PlayerCharacter>();
            if (actor == null)
            {
                return;
            }

            TriggerEnter.Invoke();
        }
    }
}