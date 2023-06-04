using Api.Models.Rest;

namespace Api.Services.Interfaces
{
    public interface IEvaluationService
    {
        public List<EvaluationResult> EvaluateEducationChoices(AnalyzePostModel analyzePostModel);
    }
}
