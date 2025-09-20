
using Employee.Core;
using Employes;
using InterfaceEmployee;
using Microsoft.EntityFrameworkCore;

namespace Employee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            DataContactObject.GetQuerryResource();
            if (DataContactObject.intDatabaseTypeId == 0)
            {
                builder.Services.AddDbContext<ConnectDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"),
                    sqlServerOptions => sqlServerOptions.CommandTimeout(300));
                });
            }
            else if (DataContactObject.intDatabaseTypeId == 1)
            {

                builder.Services.AddDbContext<ConnectDbContext>(options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgresql"),
                    sqlServerOptions => sqlServerOptions.CommandTimeout(300));
                });
            }

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEmployes, Employe>();
            builder.Services.AddScoped<IEmployesDao, EmployesDao>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
