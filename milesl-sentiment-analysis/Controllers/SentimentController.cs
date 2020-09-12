using Microsoft.AspNetCore.Mvc;
using milesl.sentiment.analysis.Services.Interfaces;
using milesl.sentiment.analysis.ViewModels.Requests;
using milesl.sentiment.analysis.ViewModels.Responses;
using System.Threading.Tasks;

namespace milesl.sentiment.analysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentController : ControllerBase
    {
        private readonly ITextAnalyticsService textAnalyticsService;

        public SentimentController(ITextAnalyticsService textAnalyticsService)
        {
            this.textAnalyticsService = textAnalyticsService;
        }

        [HttpPost]
        public async Task<ActionResult<SentimentAnalysisResponse>> Analyse([FromBody]SentimentAnalysisRequest sentimentAnalysisRequest)
        {
            var sentiment = await this.textAnalyticsService.AnalyseSentiment(sentimentAnalysisRequest.Content);
            return new SentimentAnalysisResponse() { Sentiment = sentiment };
        }
    }
}