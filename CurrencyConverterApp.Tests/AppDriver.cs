using System;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;

namespace CurrencyConverterApp.Tests
{
    public class AppDriver : IDisposable
    {
        private Application _app;
        private UIA3Automation _automation;
        private Window _mainWindow;

        public AppDriver(params string[] args)
        {
            string exePath = System.IO.Path.GetFullPath(@"..\..\..\CurrencyConverterApp\bin\Debug\CurrencyConverterApp.exe");
            string arguments = string.Join(" ", args);

            _app = Application.Launch(exePath, arguments);
            _automation = new UIA3Automation();
            _mainWindow = _app.GetMainWindow(_automation);
            _mainWindow.WaitUntilClickable(TimeSpan.FromSeconds(5));
        }

        public void SetAmount(string value)
        {
            var textBox = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("amountTextBox")).AsTextBox();
            textBox.Text = value;
        }

        public void SelectFrom(string currency)
        {
            var comboBox = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("fromCurrencyComboBox")).AsComboBox();
            comboBox.Select(currency);
        }

        public void SelectTo(string currency)
        {
            var comboBox = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("toCurrencyComboBox")).AsComboBox();
            comboBox.Select(currency);
        }

        public void ClickConvert()
        {
            var btn = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("convertButton")).AsButton();
            btn.Click();
            System.Threading.Thread.Sleep(100);
        }

        public string ResultText => _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("resultLabel")).Name;
        public string RatesText => _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("ratesLabel")).Name;
        public string StatusText => _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("rateStatusLabel")).Name;

        public string ReadMessageAndClose()
        {
            var msgBox = _mainWindow.ModalWindows.FirstOrDefault();
            if (msgBox == null) return null;
            string text = msgBox.FindFirstDescendant(cf => cf.ByControlType(FlaUI.Core.Definitions.ControlType.Text)).Name;
            var okBtn = msgBox.FindFirstDescendant(cf => cf.ByAutomationId("2")).AsButton();
            okBtn.Click();
            return text;
        }

        public void ClickRefreshRates()
        {
            var btn = _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("refreshRatesButton")).AsButton();
            btn.Click();
            System.Threading.Thread.Sleep(100);
        }

        public void Dispose()
        {
            _automation?.Dispose();
            _app?.Close();
        }
    }
}