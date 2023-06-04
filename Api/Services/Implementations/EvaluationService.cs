using Api.Models.Rest;
using Api.Services.Interfaces;
using Api.Services.Store;

namespace Api.Services.Implementations
{
    public class EvaluationService : IEvaluationService
    {
        private readonly DataStore _dataStore;

        public EvaluationService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public EvaluationResult EvaluateEducationChoices(AnalyzePostModel analyzePostModel)
        {
            var data = _dataStore.GetAllData();
            throw new NotImplementedException();
        }
    }
}
