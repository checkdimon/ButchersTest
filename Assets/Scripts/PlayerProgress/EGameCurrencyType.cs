
namespace TestTask.Progress
{
    public enum EGameCurrencyType
    {
        Coin,
        Key,
    }

    public static class CurrencyTypeExtensions
    {
        public static int GetAmount(this EGameCurrencyType currency)
        {
            return Global.PlayerProgress.CurrenciesData.GetAmount(currency);
        }

        public static void Add(this EGameCurrencyType currency, int amount)
        {
            Global.PlayerProgress.CurrenciesData.Add(currency, amount);
        }

        public static bool Spend(this EGameCurrencyType currency, int amount)
        {
            return Global.PlayerProgress.CurrenciesData.Spend(currency, amount);
        }
    }
}
