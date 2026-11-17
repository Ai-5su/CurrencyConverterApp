using System;

namespace CurrencyConverterApp
{
    public class RateService
    {
        private readonly IRateProvider _provider;

        public decimal CurrentUsdToEur { get; private set; }
        public decimal CurrentEurToUsd { get; private set; }
        public string LastError { get; private set; }

        public RateService(IRateProvider provider)
        {
            _provider = provider;
            CurrentUsdToEur = 0.88m;
            CurrentEurToUsd = 1.12m;
            LastError = null;
        }

        public bool Refresh()
        {
            try
            {
                decimal newRate = _provider.GetRate("USD", "EUR");

                if (newRate <= 0)
                {
                    throw new Exception("Получен неверный курс (меньше или равен нулю).");
                }

                CurrentUsdToEur = newRate;
                CurrentEurToUsd = 1m / newRate;
                LastError = null;
                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }
    }
}