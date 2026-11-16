using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterApp.Tests
{
    [TestClass]
    public class BoundaryConditionTests
    {
        private CurrencyConverter _converter;

        [TestInitialize]
        public void SetUp()
        {
            _converter = new CurrencyConverter();
        }

        [TestMethod]
        public void AmountZero_IsAllowed_ReturnsZero()
        {
            decimal result = _converter.Convert(0m, "USD", "EUR");

            Assert.AreEqual(0m, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeAmount_IsNotAllowed()
        {
            _converter.Convert(-100m, "USD", "EUR");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SmallestNegativeAmount_IsNotAllowed()
        {
            _converter.Convert(-0.01m, "EUR", "USD");
        }

        [TestMethod]
        public void SmallestPositiveAmount_IsAllowed()
        {
            decimal result = _converter.Convert(0.01m, "USD", "EUR");

            Assert.AreEqual(0.0088m, result);
        }

        [TestMethod]
        public void VeryLargeAmount_UsdToEur_DoesNotThrow()
        {
            decimal result = _converter.Convert(decimal.MaxValue, "USD", "EUR");

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void VeryLargeAmount_EurToUsd_ThrowsOverflowException()
        {
            // 1.12 > 1, поэтому результат не помещается в decimal
            _converter.Convert(decimal.MaxValue, "EUR", "USD");
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void EmptyCurrency_IsNotSupported()
        {
            _converter.Convert(10m, "", "EUR");
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void LowercaseCurrency_IsNotSupported()
        {
            _converter.Convert(10m, "usd", "eur");
        }
    }
}