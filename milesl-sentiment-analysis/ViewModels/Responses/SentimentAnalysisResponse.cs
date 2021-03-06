﻿using System.Collections.Generic;

namespace milesl.sentiment.analysis.ViewModels.Responses
{
    /// <summary>
    /// Response for sentiment analysis
    /// </summary>
    public class SentimentAnalysisResponse
    {
        /// <summary>
        /// Gets or sets the sentiment result.
        /// </summary>
        /// <value>
        /// The sentiment result.
        /// </value>
        public string SentimentResult { get; set; }

        /// <summary>
        /// Gets or sets the confidence scores.
        /// </summary>
        /// <value>
        /// The confidence scores.
        /// </value>
        public IDictionary<string, double> ConfidenceScores { get; set; }

        /// <summary>
        /// Gets or sets the confidence score.
        /// </summary>
        /// <value>
        /// The confidence score.
        /// </value>
        public double ConfidenceScore { get; set; }
    }
}