namespace milesl.sentiment.analysis.Models.Interfaces
{
    /// <summary>
    /// Interface for sentiment analysis
    /// </summary>
    public interface ISentimentAnalysisModel
    {
        /// <summary>
        /// Gets or sets the sentiment result.
        /// </summary>
        /// <value>
        /// The sentiment result.
        /// </value>
        string SentimentResult { get; set; }
    }
}