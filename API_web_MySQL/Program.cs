
using API_web_MySQL.Data;
using API_web_MySQL.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace API_web_MySQL
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

            builder.Services.AddScoped<IDepotUsers, DepotUsersMySQL>();

            builder.Services.AddControllers();
            builder.Services.AddScoped<ManipulationUser>();


            builder.Services.AddControllersWithViews();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            using var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            try
            {
                // Seed database
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetService<ApplicationDbContext>();
                    DbInitializer.Initialize(context);

                };

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
            //app.UseHttpsRedirection();    //DL : Remettre en service pour la production HTTPS

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}