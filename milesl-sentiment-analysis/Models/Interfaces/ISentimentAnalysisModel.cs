using System.Collections.Generic;

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

        /// <summary>
        /// Gets or sets the confidence score.
        /// </summary>
        /// <value>
        /// The confidence score.
        /// </value>
        double ConfidenceScore { get; }

        /// <summary>
        /// Gets or sets the confidence scores.
        /// </summary>
        /// <value>
        /// The confidence scores.
        /// </value>
        IDictionary<string, double> ConfidenceScores { get; set; }
    }
}