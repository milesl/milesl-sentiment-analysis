using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;
using milesl.sentiment.analysis.Configuration;
using milesl.sentiment.analysis.Models;
using milesl.sentiment.analysis.Models.Interfaces;
using milesl.sentiment.analysis.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace milesl.sentiment.analysis.Services
{
    /// <summary>
    /// Service for working with the text analytics service
    /// </summary>
    /// <seealso cref="milesl.sentiment.analysis.Services.Interfaces.ITextAnalyticsService" />
    public class TextAnalyticsService : ITextAnalyticsService
    {
        /// <summary>
        /// The text analytics client
        /// </summary>
        private readonly TextAnalyticsClient textAnalyticsClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsService"/> class.
        /// </summary>
        /// <param name="textAnalyticsConfig">The text analytics configuration.</param>
        public TextAnalyticsService(IOptions<TextAnalyticsConfig> textAnalyticsConfig)
        {
            this.textAnalyticsClient = new TextAnalyticsClient(textAnalyticsConfig.Value.EndPoint, new AzureKeyCredential(textAnalyticsConfig.Value.AnalyticsKey););
        }

        /// <summary>
        /// Analyses the sentiment of the provided content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        /// The sentiment result for the content.
        /// </returns>
        public async Task<ISentimentAnalysisModel> AnalyseSentiment(string content)
        {
            DocumentSentiment documentSentiment = await this.textAnalyticsClient.AnalyzeSentimentAsync(content);

            var result = new SentimentAnalysisModel()
            {
                SentimentResult = documentSentiment.Sentiment.ToString(),
                ConfidenceScores = new Dictionary<string, double>() {
                    { "Neutral", documentSentiment.ConfidenceScores.Neutral },
                    { "Positive", documentSentiment.ConfidenceScores.Positive },
                    { "Negative", documentSentiment.ConfidenceScores.Negative }
                }
            };

            return result;
        }
    }
}