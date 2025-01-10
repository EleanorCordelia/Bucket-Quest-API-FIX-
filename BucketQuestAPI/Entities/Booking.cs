namespace BucketQuestAPI.Entities;

public class Booking
{
    public int Id { get; set; }
    public string? ContactName { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public int Participants { get; set; }
    public int TotalPrice { get; set; }
    public Account? Booker { get; set; }
    public TripPackage? TripPackage { get; set; }
    public DateOnly Date { get; set; }
}