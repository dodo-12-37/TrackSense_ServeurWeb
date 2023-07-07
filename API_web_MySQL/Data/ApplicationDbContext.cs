using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace API_web_MySQL.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
