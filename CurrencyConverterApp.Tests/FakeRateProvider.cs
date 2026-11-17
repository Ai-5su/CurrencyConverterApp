namespace CurrencyConverterApp.Tests
{
    public class FakeRateProvider : IRateProvider
    {
        public decimal RateToReturn { get; set; } = 0.90m;
        public bool ShouldThrowError { get; set; } = false;

        public decimal GetRate(string fromCurrency, string toCurrency)
        {
            if (ShouldThrowError)
            {
                throw new System.Exception("Тестовая ошибка сети");
            }
            return RateToReturn;
        }
    }
}