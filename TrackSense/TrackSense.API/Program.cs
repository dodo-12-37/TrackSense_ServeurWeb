using Microsoft.EntityFrameworkCore;

using TrackSense.API.Entities.Interfaces;
using TrackSense.API.Data;
using TrackSense.API.Services.ServiceUsers;
using TrackSense.API.Services.ServiceRides;

namespace TrackSense.API
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString, b => b.MigrationsAssembly("tracksense")));
            Console.WriteLine("Connection String: " + connectionString);

            builder.Services.AddSingleton<IDepotUsers, DepotUsersMySQL>();
            builder.Services.AddSingleton<IDepotRides, DepotRidesMySQL>();

            builder.Services.AddSingleton<ManipulationUsers>();
            builder.Services.AddSingleton<ManipulationRides>();

            builder.Services.AddControllers();

            builder.Services.AddControllersWithViews();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}
