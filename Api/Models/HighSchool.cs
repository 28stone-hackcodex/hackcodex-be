namespace Api.Models
{
    public class HighSchool
    {
        public string RegistrationNumber { get; set; } // ID
        public string NameOfInstitution { get; set; }

        public string Municipality { get; set; } // TODO: get rid of it
        public Guid LocationId { get; set; }
        public List<Guid> HighSchoolProgramIds { get; set; }
    }
}
