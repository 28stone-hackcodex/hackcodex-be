using System.Text.Json.Serialization;

namespace Api.Models
{
    public class JsonDbContext
    {
        public List<Municipality> Municipalities { get; set; }
        public List<Location> Locations { get; set; }

        public List<InterestArea> InterestAreas { get; set; }
        public List<SchoolSubject> SchoolSubjects { get; set; }

        public List<HighSchool> HighSchools { get; set; }
        public List<HighSchoolProgram> HighSchoolPrograms { get; set; }

        public List<Weight> HighSchoolProgramsSchoolSubjectWeights { get; set; }
        public List<Weight> HighSchoolProgramsInterestAreaWeights { get; set; }
    }
}
