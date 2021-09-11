﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Repository.Context
{
    public class FalconDBContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<MRole> MRole { get; set; }
        public DbSet<RiskCategory> RiskCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_URI"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                        .Property(a => a.CreatedDate)
                        .HasDefaultValue("getdate()");

            modelBuilder.Entity<Division>()
                        .Property(d => d.CreatedDate)
                        .HasDefaultValue("getdate()");

            modelBuilder.Entity<Department>()
                        .Property(de => de.CreatedDate)
                        .HasDefaultValue("getdate()");

            modelBuilder.Entity<MRole>()
                        .Property(mr => mr.CreatedDate)
                        .HasDefaultValue("getdate()");

            modelBuilder.Entity<User>()
                        .Property(u => u.CreatedDate)
                        .HasDefaultValue("getdate()");

            modelBuilder.Entity<User>()
                        .Property(u => u.Id)
                        .HasDefaultValue("newid()");

        }
    }
}
