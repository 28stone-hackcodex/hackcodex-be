namespace Api.Models
{
    public class ManyToManyMap<Source, Dest>
    {
        public Source Id1 { get; set; }
        public Dest Id2 { get; set; }
    }
}
