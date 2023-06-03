namespace Api.Models
{
    public class JsonDbContext
    {
        public List<City> Cities { get; set; }
        public List<Location> Locations { get; set; }

        public List<InterestArea> InterestAreas { get; set; }
        public List<SchoolSubject> SchoolSubjects { get; set; }

        public List<University> Universities { get; set; }
        public List<UniversityProgram> UniversityPrograms { get; set; }

        public List<Weight> UniversityProgramsSchoolSubjectWeights { get; set; }
        public List<Weight> UniversityProgramsInterestAreaWeights { get; set; }
    }
}
