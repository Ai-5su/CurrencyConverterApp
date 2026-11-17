namespace CurrencyConverterApp
{
    public interface IRateProvider
    {
        decimal GetRate(string fromCurrency, string toCurrency);
    }
}