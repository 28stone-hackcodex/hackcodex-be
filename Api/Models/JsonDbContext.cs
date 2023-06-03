namespace Api.Models
{
    public class JsonDbContext
    {
        public List<City> Cities { get; set; }
        public List<Location> Locations { get; set; }

        public List<InterestArea> InterestAreas { get; set; }
        public List<SchoolSubject> SchoolSubjects { get; set; }

        public List<HighSchool> HighSchools { get; set; }
        public List<HighSchoolProgram> HighSchoolPrograms { get; set; }

        public List<Weight> HighSchoolProgramsSchoolSubjectWeights { get; set; }
        public List<Weight> HighSchoolProgramsInterestAreaWeights { get; set; }
    }
}
