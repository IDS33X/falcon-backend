using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        public DbSet<Risk> Risk { get; set; }
        public DbSet<RiskImpact> RiskImpact { get; set; }
        public DbSet<ImpactType> ImpactType { get; set; }

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

            modelBuilder.Entity<Risk>()
                        .Property(r => r.Id)
                        .HasDefaultValueSql("newid()");
            
            modelBuilder.Entity<Risk>()
                        .Property(r => r.CreationDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ImpactType>()
                        .Property(i => i.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MRole>().HasData(new MRole[]
            {
                new MRole { Title = "Administrador", Description = "Administra las areas, divisiones, departamento y los usuarios"},
                new MRole { Title = "Analista de riesgos", Description = "Administra los riesgos y controles"},
            });

            modelBuilder.Entity<ImpactType>().HasData(new ImpactType[] { 
                new ImpactType { Title = "Bajo", Description = "Nivel bajo de riesgo" },
                new ImpactType { Title = "Medio", Description = "Nivel medio de riesgo" },
                new ImpactType { Title = "Alto", Description = "Nivel alto de riesgo" }
            });

            modelBuilder.Entity<RiskImpact>().HasData(new RiskImpact[]
            {
                new RiskImpact { ImpactTypeId = 1, Severity = 1, Probability = 1 },
                new RiskImpact { ImpactTypeId = 1, Severity = 1, Probability = 2 },
                new RiskImpact { ImpactTypeId = 1, Severity = 1, Probability = 3 },
                new RiskImpact { ImpactTypeId = 2, Severity = 1, Probability = 4 },
                new RiskImpact { ImpactTypeId = 2, Severity = 1, Probability = 5 },
                new RiskImpact { ImpactTypeId = 1, Severity = 2, Probability = 1 },
                new RiskImpact { ImpactTypeId = 1, Severity = 2, Probability = 2 },
                new RiskImpact { ImpactTypeId = 2, Severity = 2, Probability = 3 },
                new RiskImpact { ImpactTypeId = 2, Severity = 2, Probability = 4 },
                new RiskImpact { ImpactTypeId = 2, Severity = 2, Probability = 5 },
                new RiskImpact { ImpactTypeId = 2, Severity = 3, Probability = 1 },
                new RiskImpact { ImpactTypeId = 2, Severity = 3, Probability = 2 },
                new RiskImpact { ImpactTypeId = 2, Severity = 3, Probability = 3 },
                new RiskImpact { ImpactTypeId = 3, Severity = 3, Probability = 4 },
                new RiskImpact { ImpactTypeId = 3, Severity = 3, Probability = 5 },
                new RiskImpact { ImpactTypeId = 2, Severity = 4, Probability = 1 },
                new RiskImpact { ImpactTypeId = 2, Severity = 4, Probability = 2 },
                new RiskImpact { ImpactTypeId = 3, Severity = 4, Probability = 3 },
                new RiskImpact { ImpactTypeId = 3, Severity = 4, Probability = 4 },
                new RiskImpact { ImpactTypeId = 3, Severity = 4, Probability = 5 },
                new RiskImpact { ImpactTypeId = 2, Severity = 5, Probability = 1 },
                new RiskImpact { ImpactTypeId = 3, Severity = 5, Probability = 2 },
                new RiskImpact { ImpactTypeId = 3, Severity = 5, Probability = 3 },
                new RiskImpact { ImpactTypeId = 3, Severity = 5, Probability = 4 },
                new RiskImpact { ImpactTypeId = 3, Severity = 5, Probability = 5 },
            });
        }
    }
}
