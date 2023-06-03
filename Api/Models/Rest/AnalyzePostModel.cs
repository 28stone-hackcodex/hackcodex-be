namespace Api.Models.Rest
{
    /// <summary>
    /// Not stored in Db, just contains input data from user for evaluation
    /// </summary>
    public class AnalyzePostModel
    {
        public int MaxCount { get; set; }

        public int AvailiableBudget { get; set; }

        public Location ResidentalLocation { get; set; }
        public List<Tuple<Guid, decimal>> SchoolMarksBySchoolSubjectId { get; set; }
        public List<Guid> InterestFieldsIds { get; set; }
    }
}
