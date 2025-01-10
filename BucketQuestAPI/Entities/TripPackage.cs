using Entities;

namespace BucketQuestAPI.Entities;

public class TripPackage
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Trip>? Trips { get; set; }
    public string? Location { get; set; }
    
}