using Domain.Entities;
using Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Context
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<Tab> Tabs { get; set; }
        public DbSet<DirectoryTab> Directory { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public WriteDbContext()
        {

        }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-OFID19A\\MSSQLSERVERTYMEK;Database=TabManagerDB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tabmanager");

            var configuration = new WriteDbContextConfiguration();
            modelBuilder.ApplyConfiguration<Tab>(configuration);
            modelBuilder.ApplyConfiguration<DirectoryTab>(configuration);
            modelBuilder.ApplyConfiguration<ApplicationUser>(configuration);
        }
    }
}
