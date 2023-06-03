using System.Text.Json.Serialization;

namespace Api.Models
{
    public class JsonDbContext
    {
        public List<Municipality> Municipalities { get; set; }
        public List<Location> Locations { get; set; }

        public List<InterestArea> InterestAreas { get; set; }
        public List<SchoolSubject> SchoolSubjects { get; set; }

        public List<HighSchool> HighSchools { get; set; } // from schools.json
        public List<ManyToManyMap<string, Guid>> HighSchoolsHighSchoolPrograms { get; set; } // pairs of HighSchool RegistrationNumber and High School program id to determine which highschool hs which program
        public List<HighSchoolProgram> HighSchoolPrograms { get; set; }

        public List<Weight> HighSchoolProgramsSchoolSubjectWeights { get; set; }
        public List<Weight> HighSchoolProgramsInterestAreaWeights { get; set; }
    }
}
