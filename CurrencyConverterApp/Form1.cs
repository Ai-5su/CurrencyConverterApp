using System;
using System.Windows.Forms;

namespace CurrencyConverterApp
{
    public partial class Form1 : Form
    {
        private CurrencyConverter converter = new CurrencyConverter();

        public Form1()
        {
            InitializeComponent();
            fromCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });
            toCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });
            fromCurrencyComboBox.SelectedIndex = 0;
            toCurrencyComboBox.SelectedIndex = 1;
        }

        public void convertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                ShowMessage("Введите сумму для конвертации!");
                return;
            }

            decimal amount;
            string text = amountTextBox.Text.Replace('.', ',');
            if (!decimal.TryParse(text, out amount))
            {
                ShowMessage("Неверный формат суммы!");
                return;
            }

            string fromCurrency = fromCurrencyComboBox.SelectedItem.ToString();
            string toCurrency = toCurrencyComboBox.SelectedItem.ToString();

            try
            {
                decimal result = converter.Convert(amount, fromCurrency, toCurrency);
                resultLabel.Text = $"Результат: {amount} {fromCurrency} = {result:F2} {toCurrency}";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        protected virtual void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}