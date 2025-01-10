using BucketQuestAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BucketQuestAPI.Data;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public required DbSet<Account> Accounts { get; set; }
    public required DbSet<Activity> Activities { get; set; }
    public required DbSet<Location> Locations { get; set; }
    public required DbSet<Package> Packages { get; set; }
}