namespace Entities;

public class ActivityType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public List<Trip>? Trips { get; set; }
}