namespace milesl.sentiment.analysis.ViewModels.Requests
{
    /// <summary>
    /// Request for sentiment analysis
    /// </summary>
    public class SentimentAnalysisRequest
    {
        /// <summary>
        /// Gets or sets the content to be analysed.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }
    }
}