using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Infrastructure.PostgresDataAccess.Entities.Topic;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("APICLEAN_CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("APICLEAN_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "ApiClean");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostgresDataAccess.Entities.Map.User.UserMap());
            modelBuilder.ApplyConfiguration(new PostgresDataAccess.Entities.Map.Topic.TopicMap());



            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }


    }
}
