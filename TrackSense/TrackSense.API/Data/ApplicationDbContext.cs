using Microsoft.EntityFrameworkCore;
using TrackSense.API.Services.DTO;

namespace TrackSense.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserDTO> UserDTOs { get; set; }
        public DbSet<LocationDTO> LocationDTOs { get; set; }
        public DbSet<AddressDTO> AddressDTOs { get; set; }
        public DbSet<PlannedRideDTO>PlannedRideDTOs { get; set; }
        public DbSet<PlannedRidePointDTO>PlannedRidePointDTOs { get; set; }
      
        public DbSet<PlannedRideStatisticsDTO> PlannedRideStatisticsDTOs { get; set; }
        public DbSet<CompletedRideDTO> CompletedRideDTOs { get; set; }
        public DbSet<CompletedRidePointDTO> CompletedRidePointDTOs { get; set; }

      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompletedRidePointDTO>().HasKey(c => new { c.CompletedRideId, c.LocationId });
            modelBuilder.Entity<PlannedRidePointDTO>().HasKey(c => new { c.PlannedRideId, c.LocationId });

*//*
            base.OnModelCreating(modelBuilder);*//*
        }*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

      
        
    }
}
