using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterApp.Tests
{
    [TestClass]
    public class UiTests
    {
        [TestMethod]
        public void TC001_ConvertUsdToEur()
        {
            using (var app = new AppDriver("--no-rates"))
            {
                app.SetAmount("100");
                app.ClickConvert();
                StringAssert.Contains(app.ResultText, "100 USD = 88,00 EUR");
            }
        }

        [TestMethod]
        public void TC002_ConvertEurToUsd()
        {
            using (var app = new AppDriver("--no-rates"))
            {
                app.SelectFrom("EUR");
                app.SelectTo("USD");
                app.SetAmount("100");
                app.ClickConvert();
                StringAssert.Contains(app.ResultText, "100 EUR = 112,00 USD");
            }
        }

        [TestMethod]
        public void TC008_NegativeAmount_ShowsMessage()
        {
            using (var app = new AppDriver("--no-rates"))
            {
                app.SetAmount("-5");
                app.ClickConvert();
                string msg = app.ReadMessageAndClose();
                StringAssert.Contains(msg, "Сумма не может быть отрицательной.");
            }
        }

        [TestMethod]
        public void TC009_EmptyAmount_ShowsMessage()
        {
            using (var app = new AppDriver("--no-rates"))
            {
                app.ClickConvert();
                string msg = app.ReadMessageAndClose();
                StringAssert.Contains(msg, "Введите сумму для конвертации!");
            }
        }

        [TestMethod]
        public void TC_RATE_003_ConvertUsesUpdatedRate()
        {
            using (var server = new FakeRateServer { Rate = 0.95m })
            using (var app = new AppDriver($"--rates-url={server.Url}", "--no-rates"))
            {
                app.ClickRefreshRates();
                app.SetAmount("100");
                app.ClickConvert();
                StringAssert.Contains(app.ResultText, "100 USD = 95,00 EUR");
            }
        }

        [TestMethod]
        public void TC_RATE_004_StartWithoutServer_UsesDefaultRates()
        {
            using (var app = new AppDriver("--rates-url=http://localhost:9999/fail"))
            {
                StringAssert.Contains(app.RatesText, "0,8800");
                StringAssert.Contains(app.StatusText, "Ошибка");
            }
        }
    }
}