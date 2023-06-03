namespace Api.Models
{
    public class University
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public List<Guid> UniversityProgramIds { get; set; }

        public int DormitoryMonthlyCost { get; set; }
        public decimal MinAvgWeightedGrade { get; set; }
    }
}
