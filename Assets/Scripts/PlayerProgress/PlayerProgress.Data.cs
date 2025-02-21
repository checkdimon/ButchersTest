
using UnityEngine;

namespace TestTask.Progress
{
    public partial class PlayerProgress
    {
        [SerializeField] private GameCurrenciesData currenciesData = new GameCurrenciesData();

        public GameCurrenciesData CurrenciesData => currenciesData;

        public void Initialize()
        {
        }

        private void SetDefaults()
        {
        }
    }
}
