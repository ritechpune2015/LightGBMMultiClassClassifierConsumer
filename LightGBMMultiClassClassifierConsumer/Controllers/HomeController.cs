using LightGBMMultiClassClassifierConsumer.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;

namespace LightGBMMultiClassClassifierConsumer.Controllers
{
    public class HomeController : Controller
    {
        private readonly PredictionEnginePool<PredictionRequest, ModelOutput> _predictionEnginePool;

        public HomeController(PredictionEnginePool<PredictionRequest, ModelOutput> predictionEnginePool)
        {
            this._predictionEnginePool = predictionEnginePool;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(PredictionRequest request)
        {
            var prediction = _predictionEnginePool.Predict(
                modelName: "HelpDesk",
                example: request);

            var response = new PredictionRequest
            {
                Category = prediction.PredictedLabel
            };
            return View(response);
        }

    }
}
