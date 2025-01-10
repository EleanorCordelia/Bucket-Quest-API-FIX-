using BucketQuestAPI.Entities;

namespace Entities;

public class Trip
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Price { get; set; }
    public string? Catatan { get; set; }
    public List<Photo>? Photos { get; set; }
    public List<ActivityType>? ActivityTypes { get; set; }
    public string? Duration { get; set; }
    public string? Location { get; set; }
    public List<string>? Itinerary { get; set; }
}