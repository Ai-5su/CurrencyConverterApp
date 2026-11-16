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

            // Заполняем списки валютами
            fromCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });
            toCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });

            // Выбираем значения по умолчанию
            fromCurrencyComboBox.SelectedIndex = 0; // USD
            toCurrencyComboBox.SelectedIndex = 1;   // EUR
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(amountTextBox.Text))
            {
                MessageBox.Show("Введите сумму для конвертации!");
                return;
            }

            decimal amount;
            string text = amountTextBox.Text.Replace('.', ',');

            if (!decimal.TryParse(text, out amount))
            {
                MessageBox.Show("Неверный формат суммы!");
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}