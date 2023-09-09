using Microsoft.EntityFrameworkCore;

using TrackSense.API.Entities.Interfaces;
using TrackSense.API.Data;
using TrackSense.API.Services.ServiceUsers;
using TrackSense.API.Services.ServiceRides;
using Microsoft.AspNetCore.Identity;
using TrackSense.API.Services.DTO;
using Org.BouncyCastle.Crypto.Macs;

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
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySQL(connectionString));
            Console.WriteLine("Connection String: " + connectionString);

            builder.Services.AddIdentity<UserDTO,IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<IDepotUsers, DepotUsersMySQL>();
            builder.Services.AddScoped<IDepotRides, DepotRidesMySQL>();

            builder.Services.AddScoped<ManipulationUsers>();
            builder.Services.AddScoped<ManipulationRides>();

            builder.Services.AddControllers();

            builder.Services.AddControllersWithViews();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

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
            
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }

    }
}
