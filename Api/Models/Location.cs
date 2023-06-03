using Api.Models.Rest;

namespace Api.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
    }
}
