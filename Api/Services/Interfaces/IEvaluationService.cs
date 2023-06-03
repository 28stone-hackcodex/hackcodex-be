using Api.Models.Rest;

namespace Api.Services.Interfaces
{
    public interface IEvaluationService
    {
        public EvaluationResult EvaluateEducationChoices(AnalyzePostModel analyzePostModel);
    }
}
