using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterApp.Tests
{
    public class FakeRateServer : IDisposable
    {
        private HttpListener _listener;
        public string Url { get; private set; }
        public decimal Rate { get; set; } = 0.90m;
        public bool ReturnError { get; set; } = false;

        public FakeRateServer()
        {
            var random = new Random();
            Url = $"http://localhost:{random.Next(10000, 20000)}/";
            _listener = new HttpListener();
            _listener.Prefixes.Add(Url);
            _listener.Start();
            Task.Run(Listen);
        }

        private async Task Listen()
        {
            while (_listener.IsListening)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    var response = context.Response;
                    if (ReturnError)
                    {
                        response.StatusCode = 500;
                    }
                    else
                    {
                        string json = $"{{\"rates\": {{\"EUR\": {Rate.ToString(System.Globalization.CultureInfo.InvariantCulture)}}}}}";
                        byte[] buffer = Encoding.UTF8.GetBytes(json);
                        response.ContentType = "application/json";
                        response.ContentLength64 = buffer.Length;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    response.Close();
                }
                catch { }
            }
        }

        public void Dispose()
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener.Close();
            }
        }
    }
}