using milesl.sentiment.analysis.Models.Interfaces;

namespace milesl.sentiment.analysis.Models
{
    /// <summary>
    /// Model for sentiment analysis
    /// </summary>
    public class SentimentAnalysisModel : ISentimentAnalysisModel
    {
        /// <summary>
        /// Gets or sets the sentiment result.
        /// </summary>
        /// <value>
        /// The sentiment result.
        /// </value>
        public string SentimentResult { get; set; }
    }
}