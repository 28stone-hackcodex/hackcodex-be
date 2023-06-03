namespace Api.Models.Rest
{
    /// <summary>
    /// Not stored in Db, just contains input data from user for evaluation
    /// </summary>
    public class AnalyzePostModel
    {
        public int AvailiableBudget { get; set; }
        public int FamilySalary { get; set; }

        public Location ResidentalLocation { get; set; }
        public Dictionary<Guid, decimal> SchoolMarksBySchoolSubjectId { get; set; }
        public Dictionary<Guid, decimal> InterestFieldStrengthByInterestAreaId { get; set; }
    }
}
