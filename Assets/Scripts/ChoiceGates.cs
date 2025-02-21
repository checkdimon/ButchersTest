using UnityEngine;

namespace TestTask.Gameplay
{
    public class ChoiceGates : MonoBehaviour
    {
        [SerializeField] private TriggerEnterEventInterceptor positiveGate;
        [SerializeField] private TriggerEnterEventInterceptor negativeGate;

        private bool isTriggered;

        private void Start()
        {
            positiveGate.TriggerEnter += () => OnGateTriggerEnter(true);
            negativeGate.TriggerEnter += () => OnGateTriggerEnter(false);
        }

        private void OnGateTriggerEnter(bool positive)
        {
            if (isTriggered)
            {
                return;
            }
            isTriggered = true;

            EventBus.ChoiñeGate.Invoke(positive);
        }
    }
}