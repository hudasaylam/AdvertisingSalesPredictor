using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Advertising.Models;

namespace Advertising.Controllers
{
    public class PredictionController : Controller
    {
        private readonly HttpClient _httpClient;

        public PredictionController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new PredictionModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(PredictionModel model)
        {
            if (ModelState.IsValid)
            {
                var requestBody = new
                {
                    features = new[] { model.TV, model.Radio, model.Newspaper }
                };

                var response = await _httpClient.PostAsJsonAsync("http://127.0.0.1:5001/predict", requestBody);
                var responseString = await response.Content.ReadAsStringAsync();
                var prediction = JsonSerializer.Deserialize<JsonElement>(responseString).GetProperty("prediction").GetDouble();

                model.Prediction = prediction;
            }

            return View(model);
        }
    }
}
