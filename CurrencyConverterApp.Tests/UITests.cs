using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyConverterApp.Tests
{
    [TestClass]
    public class UITests
    {
        private Form1 _form;

        [TestInitialize]
        public void SetUp()
        {
            _form = new Form1();
        }

        [TestCleanup]
        public void TearDown()
        {
            _form.Dispose();
        }

        [TestMethod]
        public void AmountTextBox_IsOnFormAndEnabled()
        {
            Assert.AreEqual(1, _form.Controls.Find("amountTextBox", true).Length);
            Assert.IsTrue(_form.amountTextBox.Enabled);
        }

        [TestMethod]
        public void ConvertButton_IsOnFormAndEnabled()
        {
            Assert.AreEqual(1, _form.Controls.Find("convertButton", true).Length);
            Assert.IsTrue(_form.convertButton.Enabled);
        }

        [TestMethod]
        public void FromCurrencyComboBox_IsOnFormAndEnabled()
        {
            Assert.AreEqual(1, _form.Controls.Find("fromCurrencyComboBox", true).Length);
            Assert.IsTrue(_form.fromCurrencyComboBox.Enabled);
        }

        [TestMethod]
        public void ToCurrencyComboBox_IsOnFormAndEnabled()
        {
            Assert.AreEqual(1, _form.Controls.Find("toCurrencyComboBox", true).Length);
            Assert.IsTrue(_form.toCurrencyComboBox.Enabled);
        }

        [TestMethod]
        public void ResultLabel_IsOnFormAndStartsWithResult()
        {
            Assert.AreEqual(1, _form.Controls.Find("resultLabel", true).Length);
            StringAssert.StartsWith(_form.resultLabel.Text, "Результат");
        }

        [TestMethod]
        public void ConvertButton_HasCorrectText()
        {
            Assert.AreEqual("Конвертировать", _form.convertButton.Text);
        }

        [TestMethod]
        public void CurrencyComboBoxes_AreDropDownList()
        {
            Assert.AreEqual(ComboBoxStyle.DropDownList, _form.fromCurrencyComboBox.DropDownStyle);
            Assert.AreEqual(ComboBoxStyle.DropDownList, _form.toCurrencyComboBox.DropDownStyle);
        }

        [TestMethod]
        public void Form_TitleContainsAppName()
        {
            StringAssert.Contains(_form.Text, "Конвертер валют");
        }
    }
}