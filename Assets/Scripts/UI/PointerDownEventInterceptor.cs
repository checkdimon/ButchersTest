
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestTask.UI
{
    public class PointerDownEventInterceptor : MonoBehaviour, IPointerDownHandler
    {
        public event Action OnDown;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDown?.Invoke();
        }
    }
}
