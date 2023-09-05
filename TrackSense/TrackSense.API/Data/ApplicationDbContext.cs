using Microsoft.EntityFrameworkCore;
using TrackSense.API.Entities;
using TrackSense.API.Services.DTO;

namespace TrackSense.API.Data
{
    public class ApplicationDbContext 
        : DbContext
    {
        public DbSet<UserDTO> UserDTO { get; set; }
        public DbSet<LocationDTO> LocationDTO { get; set; }
        public DbSet<AddressDTO> AddressDTO { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

      
        
    }
}
