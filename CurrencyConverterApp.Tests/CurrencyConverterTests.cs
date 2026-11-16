using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterApp.Tests
{
    [TestClass]
    public class CurrencyConverterTests
    {
        private CurrencyConverter _converter;

        [TestInitialize]
        public void SetUp()
        {
            _converter = new CurrencyConverter();
        }

        [TestMethod]
        public void Convert_UsdToEur_ReturnsCorrectAmount()
        {
            // Arrange
            decimal amount = 100m;

            // Act
            decimal result = _converter.Convert(amount, "USD", "EUR");

            // Assert
            Assert.AreEqual(88m, result);
        }

        [TestMethod]
        public void Convert_EurToUsd_ReturnsCorrectAmount()
        {
            decimal result = _converter.Convert(100m, "EUR", "USD");

            Assert.AreEqual(112m, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Convert_SameCurrency_ThrowsNotSupportedException()
        {
            // В нашей программе одинаковые валюты запрещены, поэтому ждем ошибку
            _converter.Convert(50m, "USD", "USD");
        }

        [TestMethod]
        public void Convert_OneUsd_ReturnsRate()
        {
            decimal result = _converter.Convert(1m, "USD", "EUR");

            Assert.AreEqual(0.88m, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Convert_NegativeAmount_ThrowsArgumentException()
        {
            _converter.Convert(-10m, "USD", "EUR");
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Convert_UnsupportedPair_ThrowsNotSupportedException()
        {
            _converter.Convert(10m, "USD", "RUB");
        }

        [TestMethod]
        public void Convert_NegativeAmount_ExceptionMessageIsCorrect()
        {
            try
            {
                _converter.Convert(-1m, "USD", "EUR");
                Assert.Fail("Исключение не было выброшено");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Сумма не может быть отрицательной.", ex.Message);
            }
        }
    }
}