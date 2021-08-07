using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository.Context
{
    public class FalconDbContext : DbContext
    {

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=adriel15;Database=FalconDB;User Id=SA;Password=Adonis22");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //DbSet
        public DbSet<Employee> Employees { get; set; }
    }
}