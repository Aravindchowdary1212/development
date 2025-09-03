using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

#nullable disable
namespace Employee.Core
{
    public class ConnectDbContext : DbContext
    {
        private IDbConnection DbConnection { get; }
        public ConnectDbContext() { }
        public ConnectDbContext(DbContextOptions<ConnectDbContext> options) : base(options)
        {
        }
      
        public ConnectDbContext GetDBContext(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                var optionsBuilder = new DbContextOptionsBuilder<ConnectDbContext>();
                optionsBuilder.UseSqlServer(connectionString);
                return new ConnectDbContext(optionsBuilder.Options);
            }
            else
            {
                throw new ArgumentNullException("ConnectionString is Empty");
            }
        }

        //public DbSet<DbConnectionDto> dbConnectionDtos { get; set; }
        //public DbSet<InstantQueueDto> InstantQueueDtos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DbConnectionDto>().HasNoKey();
        //    modelBuilder.Entity<ProductDraftOrderDetailsDto>().HasNoKey();
        //    modelBuilder.Entity<ListDraftOrderDetailsDto>().HasNoKey();
        //    modelBuilder.Entity<AccuItemDraftDto>().HasNoKey();
        //    modelBuilder.Entity<ProductDraftDto>().HasNoKey();
        //    modelBuilder.Entity<DigitalVDPAssetSourcesDto>().HasNoKey();
        //    modelBuilder.Entity<DigitalVDPAssetLevelsDto>().HasNoKey();
        //    modelBuilder.Entity<SharedUserDto>().HasNoKey();
        //}
    }
}