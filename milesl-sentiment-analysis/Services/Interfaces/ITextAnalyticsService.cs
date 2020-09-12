using System.Threading.Tasks;

namespace milesl.sentiment.analysis.Services.Interfaces
{
    public interface ITextAnalyticsService
    {
        Task<string> AnalyseSentiment(string content);
    }
}