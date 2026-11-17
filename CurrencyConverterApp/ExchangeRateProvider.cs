using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace CurrencyConverterApp
{
    public class ExchangeRateProvider : IRateProvider
    {
        private readonly string _apiUrl;

        public ExchangeRateProvider(string apiUrl = "https://api.frankfurter.dev/v1/latest")
        {
            _apiUrl = apiUrl;
        }

        public decimal GetRate(string fromCurrency, string toCurrency)
        {
            string requestUrl = $"{_apiUrl}?base={fromCurrency}&symbols={toCurrency}";

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(3); // Ждем не больше 3 секунд

                try
                {
                    // Скачиваем ответ
                    string json = client.GetStringAsync(requestUrl).Result;
                    return ParseRate(json, toCurrency);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ошибка при получении курса: {ex.Message}");
                }
            }
        }

        private decimal ParseRate(string json, string targetCurrency)
        {
            // Ищем в тексте ответа нужную валюту (например, "EUR": 0.88)
            string pattern = $"\"{targetCurrency}\"\\s*:\\s*([0-9.,]+)";
            Match match = Regex.Match(json, pattern);

            if (match.Success)
            {
                string rateStr = match.Groups[1].Value.Replace('.', ',');
                if (decimal.TryParse(rateStr, out decimal rate))
                {
                    return rate;
                }
            }
            throw new Exception("Не удалось разобрать курс валют из ответа API.");
        }
    }
}