using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApiClean.Domain.User;
using ApiClean.Domain.Comment;
using ApiClean.Domain.Topic;

namespace ApiClean.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }


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
            modelBuilder.ApplyConfiguration(new PostgresDataAccess.Entities.Map.Comment.CommentMap());
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }


    }
}
