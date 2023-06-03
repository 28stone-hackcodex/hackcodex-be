namespace Api.Models
{
    public class HighSchool
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public List<Guid> HighSchoolProgramIds { get; set; }

        public int DormitoryMonthlyCost { get; set; }
        public decimal MinAvgWeightedGrade { get; set; }
    }
}
