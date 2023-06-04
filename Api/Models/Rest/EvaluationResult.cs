namespace Api.Models.Rest
{
    public class EvaluationResult
    {
        public HighSchool HighSchool { get; set;}
        public HighSchoolProgram UniversityProgram { get; set; }
        public decimal Points { get; set; } // Summed weights of school grades, interest areas and family budget
    }
}
