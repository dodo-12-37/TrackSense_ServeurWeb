using Microsoft.EntityFrameworkCore;
using TrackSense.API.Entities;

namespace TrackSense.API.Data
{
    public class ApplicationDbContext 
        : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
