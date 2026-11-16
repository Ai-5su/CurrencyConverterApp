using System.Collections.Generic;

namespace CurrencyConverterApp.Tests
{
    public class TestableForm : Form1
    {
        public List<string> Messages = new List<string>();

        // Перехватываем вызов окна и записываем текст в список
        protected override void ShowMessage(string text)
        {
            Messages.Add(text);
        }
    }
}