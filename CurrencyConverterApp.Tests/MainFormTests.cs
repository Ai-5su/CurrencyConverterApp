using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterApp.Tests
{
    [TestClass]
    public class MainFormTests
    {
        private TestableForm _form;

        [TestInitialize]
        public void SetUp()
        {
            _form = new TestableForm();
        }

        [TestCleanup]
        public void TearDown()
        {
            _form.Dispose();
        }

        [TestMethod]
        public void Constructor_FillsCurrencyLists()
        {
            Assert.AreEqual(2, _form.fromCurrencyComboBox.Items.Count);
            Assert.AreEqual(2, _form.toCurrencyComboBox.Items.Count);
            Assert.AreEqual("USD", _form.fromCurrencyComboBox.SelectedItem.ToString());
            Assert.AreEqual("EUR", _form.toCurrencyComboBox.SelectedItem.ToString());
        }

        [TestMethod]
        public void ConvertButton_Click_WhenValidData_ShowsResult()
        {
            _form.amountTextBox.Text = "100";
            _form.convertButton_Click(null, EventArgs.Empty);

            StringAssert.Contains(_form.resultLabel.Text, "88");
            StringAssert.Contains(_form.resultLabel.Text, "USD");
            StringAssert.Contains(_form.resultLabel.Text, "EUR");
            Assert.AreEqual(0, _form.Messages.Count); // Нет сообщений об ошибках
        }

        [TestMethod]
        public void ConvertButton_Click_WhenEurToUsd_ShowsResult()
        {
            _form.fromCurrencyComboBox.SelectedIndex = 1; // EUR
            _form.toCurrencyComboBox.SelectedIndex = 0;   // USD
            _form.amountTextBox.Text = "100";

            _form.convertButton_Click(null, EventArgs.Empty);

            StringAssert.Contains(_form.resultLabel.Text, "112");
        }

        [TestMethod]
        public void ConvertButton_Click_WhenSameCurrency_ShowsError()
        {
            _form.fromCurrencyComboBox.SelectedIndex = 0; // USD
            _form.toCurrencyComboBox.SelectedIndex = 0;   // USD
            _form.amountTextBox.Text = "50";

            _form.convertButton_Click(null, EventArgs.Empty);

            // Наша программа должна выдать ошибку, так как валюты одинаковые
            Assert.AreEqual(1, _form.Messages.Count);
            Assert.AreEqual("Не поддерживаемая пара валют.", _form.Messages[0]);
        }

        [TestMethod]
        public void ConvertButton_Click_WhenAmountEmpty_ShowsMessage()
        {
            string before = _form.resultLabel.Text;
            _form.amountTextBox.Text = "";

            _form.convertButton_Click(null, EventArgs.Empty);

            Assert.AreEqual(1, _form.Messages.Count);
            Assert.AreEqual("Введите сумму для конвертации!", _form.Messages[0]);
            Assert.AreEqual(before, _form.resultLabel.Text);
        }

        [TestMethod]
        public void ConvertButton_Click_WhenAmountIsText_ShowsFormatError()
        {
            _form.amountTextBox.Text = "abc";

            _form.convertButton_Click(null, EventArgs.Empty);

            Assert.AreEqual(1, _form.Messages.Count);
            Assert.AreEqual("Неверный формат суммы!", _form.Messages[0]);
        }

        [TestMethod]
        public void ConvertButton_Click_WhenNegativeAmount_ShowsError()
        {
            _form.amountTextBox.Text = "-5";

            _form.convertButton_Click(null, EventArgs.Empty);

            Assert.AreEqual(1, _form.Messages.Count);
            Assert.AreEqual("Сумма не может быть отрицательной.", _form.Messages[0]);
        }

        [TestMethod]
        public void ConvertButton_Click_WhenDotSeparator_NoError()
        {
            _form.amountTextBox.Text = "10.5";

            _form.convertButton_Click(null, EventArgs.Empty);

            Assert.AreEqual(0, _form.Messages.Count); // Ошибки быть не должно
        }

        [TestMethod]
        public void ConvertButton_Click_WhenUnsupportedPair_ShowsError()
        {
            _form.fromCurrencyComboBox.Items.Add("RUB");
            _form.fromCurrencyComboBox.SelectedIndex = 2; // RUB
            _form.amountTextBox.Text = "100";

            _form.convertButton_Click(null, EventArgs.Empty);

            Assert.AreEqual(1, _form.Messages.Count);
            Assert.AreEqual("Не поддерживаемая пара валют.", _form.Messages[0]);
        }
    }
}