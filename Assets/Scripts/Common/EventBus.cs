
using TestTask.Progress;
using TestTask.Gameplay;
using UnityEngine.Events;

namespace TestTask
{
    public static class EventBus
    {
        public static UnityEvent GameInitialized = new UnityEvent();

        public static UnityEvent<EGameCurrencyType> CurrencyAmountChanged = new UnityEvent<EGameCurrencyType>();
        public static UnityEvent<EPickableObjectType> PickableObjectCollected = new UnityEvent<EPickableObjectType>();
        public static UnityEvent<bool> ChoiñeGate = new UnityEvent<bool>();
    }
}
