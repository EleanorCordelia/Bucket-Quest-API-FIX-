using Microsoft.AspNetCore.Mvc;

namespace BucketQuestAPI.DTOs;

public class PackageSearchDto
{
    [FromQuery(Name = "name")]
    public string? Name { get; set; }
    [FromQuery(Name = "location")]
    public string? Location { get; set; }
    [FromQuery(Name = "budget")]
    public int? Budget { get; set; }
    [FromQuery(Name = "activity_type")]
    public int? ActivityType { get; set; }
    [FromQuery(Name = "participants")]
    public int Participants { get; set; } = 1;
}