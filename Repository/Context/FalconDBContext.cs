using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Context
{
    public class FalconDBContext : DbContext
    {
        //private readonly string _connectionString;

        public FalconDBContext(DbContextOptions<FalconDBContext> options) : base(options)
        {
        }

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
        public DbSet<Control> Control { get; set; }
        public DbSet<MAutomationLevel> MAutomationLevel { get; set; }
        public DbSet<MControlState> MControlState { get; set; }
        public DbSet<MControlType> MControlType { get; set; }
        public DbSet<RiskControl> RisKControl { get; set; }
        public DbSet<UserControl> UserControl { get; set; }

        //public FalconDBContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:falconrcms.database.windows.net,1433;Initial Catalog=falconTestDB;Persist Security Info=False;User ID=Falcon;Password=F@lcon123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    //optionsBuilder.UseSqlServer(_connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Risk>()
            .HasOne(r => r.InherentRisk)
            .WithMany(ir => ir.RisksInherent)
            .HasForeignKey(r => r.InherentRiskId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Risk>()
            .HasOne(r => r.ControlledRisk)
            .WithMany(ir => ir.RisksControlled)
            .HasForeignKey(r => r.ControlledRiskId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Risk>()
                .HasIndex(r => r.Code)
                .IsUnique();

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

            modelBuilder.Entity<Control>()
                        .Property(c => c.CreationDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Control>()
                        .Property(c => c.LastUpdateDate)
                        .ValueGeneratedOnAddOrUpdate();

            modelBuilder.Entity<MAutomationLevel>()
                        .Property(ma => ma.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MControlState>()
                        .Property(mc => mc.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MControlType>()
                        .Property(mct => mct.CreatedDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserControl>()
                        .Property(uc => uc.AssignDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RiskControl>()
                        .Property(rc => rc.AssignDate)
                        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserControl>()
                        .HasKey(uc => new { uc.ControlId, uc.UserId });

            modelBuilder.Entity<UserControl>()
                .HasOne<UserProfile>(uc => uc.User)
                .WithMany(up => up.Controls)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserControl>()
                .HasOne<Control>(uc => uc.Control)
                .WithMany(up => up.Users)
                .HasForeignKey(uc => uc.ControlId);

            modelBuilder.Entity<RiskControl>()
                        .HasKey(rc => new { rc.ControlId, rc.RiskId });

            modelBuilder.Entity<RiskControl>()
                .HasOne<Risk>(rc => rc.Risk)
                .WithMany(r => r.Controls)
                .HasForeignKey(rc => rc.RiskId);

            modelBuilder.Entity<RiskControl>()
                .HasOne<Control>(rc => rc.Control)
                .WithMany(c => c.Risks)
                .HasForeignKey(rc => rc.ControlId);

            modelBuilder.Entity<Control>()
                .HasIndex(c => c.Code)
                .IsUnique();



            //modelBuilder.Entity<MRole>().HasData(new MRole[]
            //{
            //    new MRole { Id=1,Title = "Administrador", Description = "Administra las areas, divisiones, departamento y los usuarios"},
            //    new MRole { Id=2,Title = "Analista de riesgos", Description = "Administra los riesgos y controles"},
            //});

            //modelBuilder.Entity<ImpactType>().HasData(new ImpactType[] {
            //    new ImpactType { Id=1,Title = "Bajo", Description = "Nivel bajo de riesgo" },
            //    new ImpactType { Id=2,Title = "Medio", Description = "Nivel medio de riesgo" },
            //    new ImpactType { Id=3,Title = "Alto", Description = "Nivel alto de riesgo" }
            //});

            //modelBuilder.Entity<RiskImpact>().HasData(new RiskImpact[]
            //{
            //    new RiskImpact { Id=1,ImpactTypeId = 1, Severity = 1, Probability = 1 },
            //    new RiskImpact { Id=2,ImpactTypeId = 1, Severity = 1, Probability = 2 },
            //    new RiskImpact { Id=3,ImpactTypeId = 1, Severity = 1, Probability = 3 },
            //    new RiskImpact { Id=4,ImpactTypeId = 2, Severity = 1, Probability = 4 },
            //    new RiskImpact { Id=5,ImpactTypeId = 2, Severity = 1, Probability = 5 },
            //    new RiskImpact { Id=6,ImpactTypeId = 1, Severity = 2, Probability = 1 },
            //    new RiskImpact { Id=7,ImpactTypeId = 1, Severity = 2, Probability = 2 },
            //    new RiskImpact { Id=8,ImpactTypeId = 2, Severity = 2, Probability = 3 },
            //    new RiskImpact { Id=9,ImpactTypeId = 2, Severity = 2, Probability = 4 },
            //    new RiskImpact { Id=10,ImpactTypeId = 2, Severity = 2, Probability = 5 },
            //    new RiskImpact { Id=11,ImpactTypeId = 2, Severity = 3, Probability = 1 },
            //    new RiskImpact { Id=12,ImpactTypeId = 2, Severity = 3, Probability = 2 },
            //    new RiskImpact { Id=13,ImpactTypeId = 2, Severity = 3, Probability = 3 },
            //    new RiskImpact { Id=14,ImpactTypeId = 3, Severity = 3, Probability = 4 },
            //    new RiskImpact { Id=15,ImpactTypeId = 3, Severity = 3, Probability = 5 },
            //    new RiskImpact { Id=16,ImpactTypeId = 2, Severity = 4, Probability = 1 },
            //    new RiskImpact { Id=17,ImpactTypeId = 2, Severity = 4, Probability = 2 },
            //    new RiskImpact { Id=18,ImpactTypeId = 3, Severity = 4, Probability = 3 },
            //    new RiskImpact { Id=19,ImpactTypeId = 3, Severity = 4, Probability = 4 },
            //    new RiskImpact { Id=20,ImpactTypeId = 3, Severity = 4, Probability = 5 },
            //    new RiskImpact { Id=21,ImpactTypeId = 2, Severity = 5, Probability = 1 },
            //    new RiskImpact { Id=22,ImpactTypeId = 3, Severity = 5, Probability = 2 },
            //    new RiskImpact { Id=23,ImpactTypeId = 3, Severity = 5, Probability = 3 },
            //    new RiskImpact { Id=24,ImpactTypeId = 3, Severity = 5, Probability = 4 },
            //    new RiskImpact { Id=25,ImpactTypeId = 3, Severity = 5, Probability = 5 },
            //});
        }
    }
}
