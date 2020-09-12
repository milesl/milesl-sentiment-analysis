using Microsoft.AspNetCore.Mvc;
using milesl.sentiment.analysis.Models.Interfaces;
using milesl.sentiment.analysis.Services.Interfaces;
using milesl.sentiment.analysis.ViewModels.Requests;
using milesl.sentiment.analysis.ViewModels.Responses;
using System.Threading.Tasks;

namespace milesl.sentiment.analysis.Controllers
{
    /// <summary>
    /// Controller for working with sentiment analysis
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentController : ControllerBase
    {
        /// <summary>
        /// The text analytics service
        /// </summary>
        private readonly ITextAnalyticsService textAnalyticsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentController"/> class.
        /// </summary>
        /// <param name="textAnalyticsService">The text analytics service.</param>
        public SentimentController(ITextAnalyticsService textAnalyticsService)
        {
            this.textAnalyticsService = textAnalyticsService;
        }

        /// <summary>
        /// Analyses the specified sentiment analysis request.
        /// </summary>
        /// <param name="sentimentAnalysisRequest">The sentiment analysis request.</param>
        /// <returns>
        /// A sentiment analysis response
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<SentimentAnalysisResponse>> Analyse([FromBody]SentimentAnalysisRequest sentimentAnalysisRequest)
        {
            var sentiment = await this.textAnalyticsService.AnalyseSentiment(sentimentAnalysisRequest.Content);

            return this.MapResult(sentiment);
        }

        /// <summary>
        /// Maps the result.
        /// </summary>
        /// <param name="sentimentAnalysisModel">The sentiment analysis model.</param>
        /// <returns> 
        /// A sentiment analysis response
        /// </returns>
        private SentimentAnalysisResponse MapResult(ISentimentAnalysisModel sentimentAnalysisModel)
        {
            return new SentimentAnalysisResponse()
            {
                Sentiment = sentimentAnalysisModel.SentimentResult
            };
        }
    }
}