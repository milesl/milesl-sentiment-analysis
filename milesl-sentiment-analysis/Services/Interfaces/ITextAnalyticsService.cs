using System.Threading.Tasks;

namespace milesl.sentiment.analysis.Services.Interfaces
{
    /// <summary>
    /// Service for working with the text analytics service
    /// </summary>
    public interface ITextAnalyticsService
    {
        /// <summary>
        /// Analyses the sentiment of the provided content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>The sentiment result for the content.</returns>
        Task<string> AnalyseSentiment(string content);
    }
}