using System;
using Microsoft.Extensions.ML;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Services;

namespace ChatApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentController : ControllerBase
    {
        // private readonly PredictionEnginePool<SampleObservation, SamplePrediction> _predictionEnginePool;

        // public SentimentController(PredictionEnginePool<SampleObservation, SamplePrediction> predictionEnginePool)
        // {
        //     // Get the ML Model Engine injected, for scoring
        //     _predictionEnginePool = predictionEnginePool;
        // }
        private readonly ISentimentService _service;

        public SentimentController(ISentimentService service)
        {
            // Get the ML Model Engine injected, for scoring
            _service = service;
        }


        [HttpGet("Predict")]
        public IActionResult PredictSentiment(string sentimentText)
        {
            var percentage = _service.Predict(sentimentText);

            return Ok(percentage);
        }

    }
}