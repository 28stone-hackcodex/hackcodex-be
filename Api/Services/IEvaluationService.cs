using Api.Models.Rest;

namespace Api.Services
{
    public interface IEvaluationService
    {
        public EvaluationResult EvaluateEducationChoices(AnalyzePostModel analyzePostModel);
    }
}
