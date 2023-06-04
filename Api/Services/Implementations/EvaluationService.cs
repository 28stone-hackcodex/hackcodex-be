using Api.Models;
using Api.Models.Rest;
using Api.Services.Interfaces;
using Api.Services.Store;
using System.ComponentModel.DataAnnotations;

namespace Api.Services.Implementations
{
    public class EvaluationService : IEvaluationService
    {
        private const int INTEREST_FIELDS_WEIGHT_COEF = 10; // the same as Marks (0 - 10)
        private const int SAME_MUNICIPALITY_ADDITIONAL_POINTS = 100;
        private readonly DataStore _dataStore;

        public EvaluationService(DataStore dataStore)
        {
            _dataStore = dataStore;
        }
        private void ValidateAnalyzePostModel(AnalyzePostModel analyzePostModel, JsonDbContext data)
        {
            if (analyzePostModel.MaxCount <= 0) analyzePostModel.MaxCount = 10; // TODO: move to config sometime, now ok to leave here as it is prototype project

            if (!data.Municipalities.Any(x => x.Id == analyzePostModel.ResidentalLocation.MunicipalityId))
            {
                throw new ValidationException($"Please add registered municipality ID, custom not implemented yet. Not found ID: {analyzePostModel.ResidentalLocation.MunicipalityId}");
            }
            foreach (var fld in analyzePostModel.InterestFieldsIds)
            {
                if (!data.InterestAreas.Any(x => x.Id == fld))
                {
                    throw new ValidationException($"Interest field with Id {fld} not exists");
                }
            }
            foreach (var sm in analyzePostModel.SchoolMarksBySchoolSubjectId)
            {
                if (!data.SchoolSubjects.Any(x => x.Id == sm.Item1) || sm.Item2 > 10 || sm.Item2 < 0)
                {
                    throw new ValidationException($"School subject not exists or the value incorrect. id: {sm.Item1}, value: {sm.Item2}");
                }
            }
        }
        public List<EvaluationResult> EvaluateEducationChoices(AnalyzePostModel analyzePostModel) // TODO: Refactor
        {
            var data = _dataStore.GetAllData();
            ValidateAnalyzePostModel(analyzePostModel, data);

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
                    var highSchoolObj = data.HighSchools.FirstOrDefault(x => x.RegistrationNumber == hshsp.Id1); // TODO: modify data to be able to use "First()"
                    var municipalityId = data.Locations.FirstOrDefault(x => x.Id == highSchoolObj.LocationId)?.MunicipalityId;
                    var extraPoints = (analyzePostModel.ResidentalLocation.MunicipalityId == municipalityId ? 1 : 0) * SAME_MUNICIPALITY_ADDITIONAL_POINTS;
                    
                    analyzeResults.Add(new EvaluationResult
                    {
                        Points = points + extraPoints,
                        HighSchool = highSchoolObj,
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
