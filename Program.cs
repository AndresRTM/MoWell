using Microsoft.EntityFrameworkCore;
using MoWell.Data;
using MoWell.Interfaces;
using MoWell.Models;
using MoWell.Repository;
using MoWell.Service;
using Scalar.AspNetCore;

namespace MoWell
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MoWellDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IHealthLogRepository, HealthLogRepository>();
            builder.Services.AddScoped<IHealthLogService, HealthLogService>();

            builder.Services.AddIdentityApiEndpoints<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<MoWellDBContext>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddAuthorization();            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();            

            app.MapIdentityApi<User>();

            app.MapControllers();

            app.Run();
        }
    }
}
