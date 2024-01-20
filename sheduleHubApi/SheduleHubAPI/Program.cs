using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace SheduleHubAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", bulder =>
            {
                bulder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            }));

            builder.Services.AddDbContext<SheduleHubContext>(
                options => options.UseSqlServer(builder.Configuration["ConnectionString"]));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
