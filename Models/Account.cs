using System.Text.Json.Serialization;

namespace TestProject.Models
{
  public class Account
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string? IncidentName { get; set; }
    public Incident? Incident { get; set; }

    [JsonIgnore]
    public List<Contact> Contacts { get; set; }
  }
}
