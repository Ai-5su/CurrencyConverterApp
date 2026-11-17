using System;
using System.Windows.Forms;

namespace CurrencyConverterApp
{
    public partial class Form1 : Form
    {
        private CurrencyConverter converter = new CurrencyConverter();
        private RateService rateService;
        private ExchangeRateProvider rateProvider;

        public Form1() : this(new string[0]) { }

        public Form1(string[] args)
        {
            InitializeComponent();

            fromCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });
            toCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });
            fromCurrencyComboBox.SelectedIndex = 0;
            toCurrencyComboBox.SelectedIndex = 1;

            string ratesUrl = null;
            bool skipRates = false;

            foreach (var arg in args)
            {
                if (arg == "--no-rates") skipRates = true;
                else if (arg.StartsWith("--rates-url=")) ratesUrl = arg.Substring(12);
                else if (arg.StartsWith("--rates-interval-ms=")) ratesTimer.Interval = int.Parse(arg.Substring(19));
            }

            rateProvider = new ExchangeRateProvider(ratesUrl);
            rateService = new RateService(rateProvider);

            ratesTimer.Start();
            if (!skipRates) RefreshRates(false);
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
            try
            {
                amount = decimal.Parse(text);
            }
            catch (FormatException)
            {
                ShowMessage("Неверный формат суммы!");
                return;
            }
            catch (OverflowException)
            {
                ShowMessage("Сумма вне допустимого диапазона. Введите число поменьше.");
                return;
            }

            string fromCurrency = fromCurrencyComboBox.SelectedItem.ToString();
            string toCurrency = toCurrencyComboBox.SelectedItem.ToString();

            try
            {
                decimal result = converter.Convert(amount, fromCurrency, toCurrency);
                resultLabel.Text = $"Результат: {amount} {fromCurrency} = {result:F2} {toCurrency}";
            }
            catch (OverflowException)
            {
                ShowMessage("Результат слишком велик для конвертации. Введите сумму поменьше.");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void refreshRatesButton_Click(object sender, EventArgs e)
        {
            RefreshRates(true);
        }

        private void ratesTimer_Tick(object sender, EventArgs e)
        {
            RefreshRates(false);
        }

        internal void RefreshRates(bool isManual)
        {
            bool success = rateService.Refresh();

            if (success)
            {
                converter.SetRates(rateService.CurrentUsdToEur, rateService.CurrentEurToUsd);
                ratesLabel.Text = $"Курсы: 1 USD = {rateService.CurrentUsdToEur:F4} EUR; 1 EUR = {rateService.CurrentEurToUsd:F4} USD";
                rateStatusLabel.Text = $"Статус: Успешно обновлено ({DateTime.Now:HH:mm:ss})";
                rateStatusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ratesLabel.Text = $"Курсы: 1 USD = {rateService.CurrentUsdToEur:F4} EUR; 1 EUR = {rateService.CurrentEurToUsd:F4} USD";
                rateStatusLabel.Text = "Статус: Ошибка обновления! Используются последние курсы.";
                rateStatusLabel.ForeColor = System.Drawing.Color.Red;

                if (isManual)
                {
                    ShowMessage($"Не удалось обновить курсы: {rateService.LastError}");
                }
            }
        }

        protected virtual void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}