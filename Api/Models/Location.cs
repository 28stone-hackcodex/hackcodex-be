namespace Api.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid MunicipalityId { get; set; }
        public string Address { get; set; }
    }
}
