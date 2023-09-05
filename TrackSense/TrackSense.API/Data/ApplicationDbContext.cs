using Microsoft.EntityFrameworkCore;
using TrackSense.API.Entities;
using TrackSense.API.Services.DTO;

namespace TrackSense.API.Data
{
    public class ApplicationDbContext 
        : DbContext
    {
        public DbSet<UserDTO> UserDTOs { get; set; }
        public DbSet<LocationDTO> LocationDTOs { get; set; }
        public DbSet<AddressDTO> AddressDTOs { get; set; }
        public DbSet<PlannedRideDTO>PlannedRideDTOs { get; set; }
        public DbSet<PlannedRidePointDTO>PlannedRidePointDTOs { get; set; }
        public DbSet<PlannedRideStatisticsDTO> PlannedRideStatisticsDTOs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

      
        
    }
}
