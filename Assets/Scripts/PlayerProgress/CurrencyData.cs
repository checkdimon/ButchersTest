
using System;

namespace TestTask.Progress
{
    [Serializable]
    public class CurrencyData<T> where T : Enum, IComparable
    {
        public T Currency;
        public int Amount;
    }
}
