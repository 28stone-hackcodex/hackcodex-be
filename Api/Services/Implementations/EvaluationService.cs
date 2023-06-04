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
        public List<EvaluationResult> EvaluateEducationChoices(AnalyzePostModel analyzePostModel)
        {
            var data = _dataStore.GetAllData();
            var analyzeResults = new List<EvaluationResult>();

            foreach (var hsp in data.HighSchoolPrograms)
            {
                var points = 0;

                foreach (var subjectWeight in data.HighSchoolProgramsSchoolSubjectWeights.Where(x => x.Id1 == hsp.Id))
                {
                }
                foreach (var interestWeight in data.HighSchoolProgramsInterestAreaWeights.Where(x => x.Id1 == hsp.Id))
                {
                }
                foreach (var hs in data.HighSchoolsHighSchoolPrograms.Where(x => x.Id2 == hsp.Id))
                {
                }
            }

            return analyzeResults
                    .OrderByDescending(x => x.Points)
                    .Take(analyzePostModel.MaxCount)
                    .ToList();
        }
    }
}
