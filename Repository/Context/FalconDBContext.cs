using Domain.Models;
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
            optionsBuilder.UseSqlServer("Server=tcp:falconrcms.database.windows.net,1433;Initial Catalog=falconTestDB;Persist Security Info=False;User ID=Falcon;Password=F@lcon123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                        .Property(a => a.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Division>()
                        .Property(d => d.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Department>()
                        .Property(de => de.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MRole>()
                        .Property(mr => mr.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                        .Property(u => u.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RiskCategory>()
            .Property(u => u.CreatedDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                        .Property(u => u.Id)
                        .HasDefaultValueSql("newid()");

        }
    }
}
