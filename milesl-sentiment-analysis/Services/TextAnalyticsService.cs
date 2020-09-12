using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;
using milesl.sentiment.analysis.Configuration;
using milesl.sentiment.analysis.Services.Interfaces;
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
        /// The text analytics configuration
        /// </summary>
        private readonly TextAnalyticsConfig textAnalyticsConfig;

        /// <summary>
        /// The azure key credential
        /// </summary>
        private readonly AzureKeyCredential azureKeyCredential;

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
            this.textAnalyticsConfig = textAnalyticsConfig.Value;
            this.azureKeyCredential = new AzureKeyCredential(this.textAnalyticsConfig.AnalyticsKey);
            this.textAnalyticsClient = new TextAnalyticsClient(this.textAnalyticsConfig.EndPoint, this.azureKeyCredential);
        }

        /// <summary>
        /// Analyses the sentiment of the provided content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        /// The sentiment result for the content.
        /// </returns>
        public async Task<string> AnalyseSentiment(string content)
        {
            DocumentSentiment documentSentiment = await this.textAnalyticsClient.AnalyzeSentimentAsync(content);
            return documentSentiment.Sentiment.ToString();
            //Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");

            //foreach (var sentence in documentSentiment.Sentences)
            //{
            //    Console.WriteLine($"\tText: \"{sentence.Text}\"");
            //    Console.WriteLine($"\tSentence sentiment: {sentence.Sentiment}");
            //    Console.WriteLine($"\tPositive score: {sentence.ConfidenceScores.Positive:0.00}");
            //    Console.WriteLine($"\tNegative score: {sentence.ConfidenceScores.Negative:0.00}");
            //    Console.WriteLine($"\tNeutral score: {sentence.ConfidenceScores.Neutral:0.00}\n");
            //}

            //return string.Empty;
        }
    }
}