using System.Collections.Generic;

namespace CurrencyConverterApp.Tests
{
    public class TestableForm : Form1
    {
        public List<string> Messages = new List<string>();

        protected override void ShowMessage(string text)
        {
            Messages.Add(text);
        }

        public void SetupFakeRates(IRateProvider provider)
        {
            var field = typeof(Form1).GetField("rateService", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (field != null)
            {
                field.SetValue(this, new RateService(provider));
            }
            RefreshRates(true);
        }
    }
}