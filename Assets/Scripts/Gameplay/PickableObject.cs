using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestTask.Gameplay
{
    public class PickableObject : MonoBehaviour
    {
        [SerializeField] private EPickableObjectType pickableObjectType;

        private bool isDestroyed;

        private void Destroy()
        {
            isDestroyed = true;
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isDestroyed)
            {
                return;
            }

            var actor = other.GetComponentInParent<PlayerCharacter>();
            if (actor == null)
            {
                return;
            }

            EventBus.PickableObjectCollected.Invoke(pickableObjectType);
            Destroy();
        }
    }
}