
using System;
using UnityEngine.Events;

namespace TestTask.Progress
{
    [Serializable]
    public class GameCurrenciesData : CurrenciesData<EGameCurrencyType>
    {
        protected override UnityEvent<EGameCurrencyType> CurrencyChanged => EventBus.CurrencyAmountChanged;
    }
}
