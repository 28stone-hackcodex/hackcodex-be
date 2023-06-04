namespace Api.Models;

public class SingleSchoolView
{
    public int Id { get; set; }
    public string SchoolName { get; set; }
    public string City { get; set; }
    public int TotalNumberOfStudents { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ContactPerson ContactPerson { get; set; }
}