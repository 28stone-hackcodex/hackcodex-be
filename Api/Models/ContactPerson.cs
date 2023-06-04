using System.Text.Json.Serialization;

namespace Api.Models;

public class ContactPerson
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string ImageUrl { get; set; }
};