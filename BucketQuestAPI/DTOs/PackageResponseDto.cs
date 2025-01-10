using Entities;

namespace BucketQuestAPI.DTOs;

public class PackageResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Trip>? Trips { get; set; }
    public string? Location { get; set; }
    public int PricePerPerson { get; set; }
    
}