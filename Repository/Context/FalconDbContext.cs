using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository.Context
{
    public class FalconDbContext : DbContext
    {

        public string ConnectionString { get; set; }

        public FalconDbContext(string ConnectionString){
            this.ConnectionString = ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        //DbSet
        public DbSet<Employee> Employees { get; set; }
    }
}