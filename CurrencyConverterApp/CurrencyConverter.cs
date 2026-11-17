using System;

namespace CurrencyConverterApp
{
    public class CurrencyConverter
    {
        private decimal usdToEur = 0.88m; // курс USD -> EUR
        private decimal eurToUsd = 1.12m; // курс EUR -> USD

        public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Сумма не может быть отрицательной.");
            }
            if (fromCurrency == "USD" && toCurrency == "EUR")
            {
                return amount * usdToEur;
            }
            else if (fromCurrency == "EUR" && toCurrency == "USD")
            {
                return amount * eurToUsd;
            }
            else
            {
                throw new NotSupportedException("Не поддерживаемая пара валют.");
            }
        }

        public void SetRates(decimal newUsdToEur, decimal newEurToUsd)
        {
            if (newUsdToEur <= 0 || newEurToUsd <= 0)
            {
                throw new ArgumentException("Курс должен быть положительным.");
            }

            usdToEur = newUsdToEur;
            eurToUsd = newEurToUsd;
        }
    }
}