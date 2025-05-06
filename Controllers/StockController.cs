using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Personal_Finance_Manager.Controllers
{
    public class StockController : Controller
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public StockController(IConfiguration config)
        {
            _config = config;
            _client = new HttpClient();
        }

        public async Task<IActionResult> Quote(string symbol = "AAPL")
        {
            string apiKey = "N90JXWPL3U18IFCY";
            string url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apiKey}";

            var response = await _client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

            // Parse the JSON response into a dynamic object
            var data = JObject.Parse(json)["Global Quote"];

            // Store the parsed data in ViewBag for use in the view
            var stockData = new
            {
                Symbol = symbol,
                Price = data?["05. price"]?.ToString(),
                Date = data?["07. latest trading day"]?.ToString()
            };

            ViewBag.StockData = stockData;  // Set the data for the view

            return View();  // Return the view with stock data in ViewBag
        }

    }
}
