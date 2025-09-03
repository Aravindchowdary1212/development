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
namespace AccuConnect.Core
{
    public class AccuConnectDbContext : DbContext
    {
        private IDbConnection DbConnection { get; }
        public AccuConnectDbContext() { }
        public AccuConnectDbContext(DbContextOptions<AccuConnectDbContext> options) : base(options)
        {
        }
      
        public AccuConnectDbContext GetDBContext(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                var optionsBuilder = new DbContextOptionsBuilder<AccuConnectDbContext>();
                optionsBuilder.UseSqlServer(connectionString);
                return new AccuConnectDbContext(optionsBuilder.Options);
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