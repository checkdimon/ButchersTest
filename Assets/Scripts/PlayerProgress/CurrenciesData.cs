
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TestTask.Progress
{
    public abstract class CurrenciesData<T> where T : Enum, IComparable
    {
        [SerializeField] private List<CurrencyData<T>> currencyDatas = new List<CurrencyData<T>>();

        protected abstract UnityEvent<T> CurrencyChanged { get; }

        public int GetAmount(T currency)
        {
            var currencyData = GetCurrencyData(currency);
            return currencyData.Amount;
        }

        public void Add(T currency, int amount)
        {
            var currencyData = GetCurrencyData(currency);
            currencyData.Amount += amount;
            CurrencyChanged?.Invoke(currency);
            Global.PlayerProgress.Save();
        }

        public bool Spend(T currency, int amount)
        {
            var currencyData = GetCurrencyData(currency);
            if (currencyData.Amount < amount)
            {
                return false;
            }
            currencyData.Amount -= amount;
            CurrencyChanged?.Invoke(currency);
            Global.PlayerProgress.Save();
            return true;
        }

        private CurrencyData<T> GetCurrencyData(T currency)
        {
            var currencyData = currencyDatas.FirstOrDefault(x => x.Currency.Equals(currency));
            if (currencyData == null)
            {
                currencyData = new CurrencyData<T>()
                {
                    Currency = currency
                };
                currencyDatas.Add(currencyData);
            }
            return currencyData;
        }
    }
}
