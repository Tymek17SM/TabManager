using Infrastructure.EF.Config;
using Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Context
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<TabReadModel> Tabs { get; set; }
        public DbSet<DirectoryTabReadModel> Directory { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("tabmanager");

            var configuration = new ReadDbContextConfiguration();
            modelBuilder.ApplyConfiguration<TabReadModel>(configuration);
            modelBuilder.ApplyConfiguration<DirectoryTabReadModel>(configuration);
        }
    }
}
