namespace Api.Models.Rest
{
    public class AnalyzeResult
    {
        public University University { get; set;}
        public UniversityProgram UniversityProgram { get; set; }
        public decimal Points { get; set; } // Summed weights of school grades, interest areas and family budget
    }
}
