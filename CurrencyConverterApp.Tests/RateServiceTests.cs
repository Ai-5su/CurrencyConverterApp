using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CurrencyConverterApp.Tests
{
    [TestClass]
    public class RateServiceTests
    {
        [TestMethod]
        public void Refresh_WhenProviderReturnsRate_UpdatesRates()
        {
            // Arrange
            var fakeProvider = new FakeRateProvider { RateToReturn = 0.85m };
            var service = new RateService(fakeProvider);

            // Act
            bool result = service.Refresh();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0.85m, service.CurrentUsdToEur);
            Assert.AreEqual(1m / 0.85m, service.CurrentEurToUsd); // Обратный курс
            Assert.IsNull(service.LastError);
        }

        [TestMethod]
        public void Refresh_WhenProviderThrowsError_KeepsLastRatesAndSetsError()
        {
            // Arrange
            var fakeProvider = new FakeRateProvider { ShouldThrowError = true };
            var service = new RateService(fakeProvider);

            // Act
            bool result = service.Refresh();

            // Assert
            Assert.IsFalse(result); // Должно вернуть false
            Assert.AreEqual(0.88m, service.CurrentUsdToEur); // Остались дефолтные
            Assert.AreEqual(1.12m, service.CurrentEurToUsd);
            StringAssert.Contains(service.LastError, "Тестовая ошибка сети");
        }
    }
}