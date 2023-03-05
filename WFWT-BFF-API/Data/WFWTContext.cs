using Microsoft.EntityFrameworkCore;
using WFWT_BFF_API.Models;

namespace WFWT_BFF_API.Data;

public class WFWTContext : DbContext
{
    public DbSet<Location> Locations { get; set; }
    public DbSet<TrackingRecord> TrackingRecords { get; set; }

    public WFWTContext(DbContextOptions<WFWTContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().ToTable("Location");
        modelBuilder.Entity<Location>().HasData(
            new Location(1, "Home", "My home"),
            new Location(2, "Work", "My work")
        );
        modelBuilder.Entity<TrackingRecord>().ToTable("TrackingRecord");
    }
}