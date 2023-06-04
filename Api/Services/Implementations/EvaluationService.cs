using Api.Models.Rest;
using Api.Services.Interfaces;
using Api.Services.Store;

namespace Api.Services.Implementations
{
    public class EvaluationService : IEvaluationService
    {
        private const int INTEREST_FIELDS_WEIGHT_COEF = 10; // the same as Marks (0 - 10)
        private readonly DataStore _dataStore;

        public EvaluationService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public List<EvaluationResult> EvaluateEducationChoices(AnalyzePostModel analyzePostModel) // TODO: Refactor
        {
            var data = _dataStore.GetAllData();
            var analyzeResults = new List<EvaluationResult>();

            foreach (var hsp in data.HighSchoolPrograms)
            {
                decimal points = 0;

                foreach (var subjectMark in analyzePostModel.SchoolMarksBySchoolSubjectId)
                {
                    foreach (var subjectWeight in data.HighSchoolProgramsSchoolSubjectWeights
                        .Where(x => x.Id1 == hsp.Id && x.Id2 == subjectMark.Item1))
                    {
                        points += subjectMark.Item2 * subjectWeight.Value;
                    }
                }

                foreach (var interestFieldId in analyzePostModel.InterestFieldsIds)
                {
                    points +=
                        INTEREST_FIELDS_WEIGHT_COEF *
                        data.HighSchoolProgramsInterestAreaWeights
                            .FirstOrDefault(x => x.Id1 == hsp.Id && x.Id2 == interestFieldId)?
                            .Value ?? 0;
                }

                foreach (var hshsp in data.HighSchoolsHighSchoolPrograms.Where(x => x.Id2 == hsp.Id)) // TODO: Define which university is better, fulfill algoritm for this
                {
                    analyzeResults.Add(new EvaluationResult
                    {
                        Points = points,
                        HighSchool = data.HighSchools.FirstOrDefault(x => x.RegistrationNumber == hshsp.Id1), // TODO: modify data to be able to use "First()"
                        UniversityProgram = hsp
                    });
                }
            }

            return analyzeResults
                    .OrderByDescending(x => x.Points)
                    .Take(analyzePostModel.MaxCount)
                    .ToList();
        }
    }
}
