using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace CurrencyConverterApp
{
    public class ExchangeRateProvider : IRateProvider
    {
        private string _baseUrl = "https://api.frankfurter.dev/v1/latest?base=USD&symbols=EUR";

        public ExchangeRateProvider() { }

        public ExchangeRateProvider(string customUrl)
        {
            if (!string.IsNullOrEmpty(customUrl))
            {
                _baseUrl = customUrl;
            }
        }

        public decimal GetRate(string fromCurrency, string toCurrency)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_baseUrl);
                request.Timeout = 3000;
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();
                    return ParseRate(json, toCurrency);
                }
            }
            catch (WebException ex)
            {
                throw new Exception($"Ошибка сети: {ex.Message}");
            }
        }

        public decimal ParseRate(string json, string targetCurrency)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new Exception("Пустой ответ от сервера.");

            if (!json.Contains("\"rates\""))
                throw new Exception("В ответе нет поля rates.");

            string pattern = $"\"{targetCurrency}\"\\s*:\\s*([0-9.,]+)";
            Match match = Regex.Match(json, pattern);

            if (!match.Success)
                throw new Exception($"В ответе нет курса для валюты {targetCurrency}.");

            string valueStr = match.Groups[1].Value.Replace('.', ',');
            if (!decimal.TryParse(valueStr, out decimal rate))
                throw new Exception("Не удалось разобрать курс.");

            if (rate <= 0)
                throw new Exception("Курс должен быть положительным.");

            return rate;
        }
    }
}