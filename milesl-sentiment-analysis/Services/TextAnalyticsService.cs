using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;
using milesl.sentiment.analysis.Configuration;
using milesl.sentiment.analysis.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace milesl.sentiment.analysis.Services
{
    public class TextAnalyticsService : ITextAnalyticsService
    {
        private readonly TextAnalyticsConfig textAnalyticsConfig;

        private readonly AzureKeyCredential azureKeyCredential;

        private readonly TextAnalyticsClient textAnalyticsClient;

        public TextAnalyticsService(IOptions<TextAnalyticsConfig> textAnalyticsConfig)
        {
            this.textAnalyticsConfig = textAnalyticsConfig.Value;
            this.azureKeyCredential = new AzureKeyCredential(this.textAnalyticsConfig.AnalyticsKey);
            this.textAnalyticsClient = new TextAnalyticsClient(this.textAnalyticsConfig.EndPoint, this.azureKeyCredential);
        }

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