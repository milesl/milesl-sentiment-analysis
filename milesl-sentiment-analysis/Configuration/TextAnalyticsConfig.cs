using System;

namespace milesl.sentiment.analysis.Configuration
{
    /// <summary>
    /// Configuration for text analytics service
    /// </summary>
    public class TextAnalyticsConfig
    {
        /// <summary>
        /// Gets or sets the azure end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        public Uri EndPoint { get; set; }

        /// <summary>
        /// Gets or sets the azure analytics key.
        /// </summary>
        /// <value>
        /// The analytics key.
        /// </value>
        public string AnalyticsKey { get; set; }
    }
}