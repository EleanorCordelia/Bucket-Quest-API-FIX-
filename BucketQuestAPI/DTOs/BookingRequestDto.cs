using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BucketQuestAPI.DTOs;

public class BookingRequestDto
{
    [Required]
    public required string ContactName { get; set; }
    [Required]
    public required string ContactEmail { get; set; }
    [Required]
    public required string ContactPhone { get; set; }
    [Required]
    public int PackageId { get; set; }
    [Required]
    public int Participants { get; set; }
    [Required]
    public required string Date { get; set; }
}