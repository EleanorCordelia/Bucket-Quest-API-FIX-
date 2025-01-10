using BucketQuestAPI.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace BucketQuestAPI.Data;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public required DbSet<Account> Accounts { get; set; }
    public required DbSet<ActivityType> ActivityTypes { get; set; }
    public required DbSet<Photo> Photos { get; set; }
    public required DbSet<Trip> Trips { get; set; }
    public required DbSet<TripPackage> TripPackages { get; set; }
    public required DbSet<Booking> Bookings { get; set; }
}