using System;
using System.Windows.Forms;

namespace CurrencyConverterApp
{
    public partial class Form1 : Form
    {
        private CurrencyConverter converter = new CurrencyConverter();

        // Наши новые сервисы для работы с курсами
        private RateService rateService;
        private ExchangeRateProvider rateProvider;

        public Form1()
        {
            InitializeComponent();

            // Настраиваем выпадающие списки
            fromCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });
            toCurrencyComboBox.Items.AddRange(new object[] { "USD", "EUR" });
            fromCurrencyComboBox.SelectedIndex = 0;
            toCurrencyComboBox.SelectedIndex = 1;

            // Инициализируем наш провайдер и сервис
            rateProvider = new ExchangeRateProvider();
            rateService = new RateService(rateProvider);

            // Запускаем таймер (он будет срабатывать каждые 10 минут)
            ratesTimer.Start();

            // Пробуем загрузить курсы сразу при запуске
            RefreshRates(false);
        }

        // Обработчик кнопки "Конвертировать"
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

        // Обработчик кнопки "Обновить курсы"
        private void refreshRatesButton_Click(object sender, EventArgs e)
        {
            RefreshRates(true);
        }

        // Обработчик таймера (срабатывает каждые 10 минут)
        private void ratesTimer_Tick(object sender, EventArgs e)
        {
            RefreshRates(false);
        }

        // Главный метод обновления курсов
        private void RefreshRates(bool isManual)
        {
            bool success = rateService.Refresh();

            if (success)
            {
                // Если курсы скачались, обновляем их в конвертере
                converter.SetRates(rateService.CurrentUsdToEur, rateService.CurrentEurToUsd);

                // Обновляем текст на форме
                ratesLabel.Text = $"Курсы: 1 USD = {rateService.CurrentUsdToEur:F4} EUR; 1 EUR = {rateService.CurrentEurToUsd:F4} USD";
                rateStatusLabel.Text = $"Статус: Успешно обновлено ({DateTime.Now:HH:mm:ss})";
                rateStatusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                // Если ошибка (например, нет интернета)
                ratesLabel.Text = $"Курсы: 1 USD = {rateService.CurrentUsdToEur:F4} EUR; 1 EUR = {rateService.CurrentEurToUsd:F4} USD";
                rateStatusLabel.Text = "Статус: Ошибка обновления! Используются последние курсы.";
                rateStatusLabel.ForeColor = System.Drawing.Color.Red;

                // Если пользователь нажал кнопку вручную, показываем окошко
                if (isManual)
                {
                    ShowMessage($"Не удалось обновить курсы: {rateService.LastError}");
                }
            }
        }

        // Специальный метод для вывода сообщений
        protected virtual void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}