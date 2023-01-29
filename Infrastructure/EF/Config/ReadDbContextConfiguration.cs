using Infrastructure.EF.Context;
using Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config
{
    internal sealed class ReadDbContextConfiguration : 
        IEntityTypeConfiguration<TabReadModel>,
        IEntityTypeConfiguration<DirectoryTabReadModel>,
        IEntityTypeConfiguration<ApplicationUserReadModel>
    {
        public void Configure(EntityTypeBuilder<TabReadModel> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder
                .Property<Guid>("DirectoryTabId");

            builder
                .HasOne(tab => tab.DirectoryTab)
                .WithMany(dir => dir.Tabs)
                .HasForeignKey("DirectoryTabId");

            builder.ToTable(TableNames.TabTable);
        }

        public void Configure(EntityTypeBuilder<DirectoryTabReadModel> builder)
        {
            builder.HasKey(dir => dir.Id);

            builder
                .Property<Guid?>("SuperiorDirectoryId")
                .IsRequired(false);

            builder
                .HasOne(dir => dir.SuperiorDirectory)
                .WithMany(d => d.SubordinateDirectories)
                .HasForeignKey("SuperiorDirectoryId");
                //.HasPrincipalKey(dir => dir.Id);

            //builder
            //    .Property<Guid?>("SubordinateDirectoryId")
            //    .IsRequired(false);

            //builder
            //    .HasOne(dir => dir.SubordinateDirectory)
            //    .WithMany()
            //    .HasForeignKey("SubordinateDirectoryId")
            //    .HasPrincipalKey(dir => dir.Id);

            builder
                .HasMany(dir => dir.SubordinateDirectories)
                .WithOne(d => d.SuperiorDirectory);
            //.HasForeignKey("SuperiorDirectoryId")
            //.HasPrincipalKey(dir => dir.Id);

            builder
                .Property<Guid>("OwnerId")
                .IsRequired(true);

            builder
                .HasOne(dir => dir.Owner)
                .WithMany(u => u.DirectoryTabs)
                .HasForeignKey("OwnerId");

            builder
                .HasMany(dir => dir.Tabs)
                .WithOne(tab => tab.DirectoryTab);

            builder.ToTable(TableNames.DirectoryTabTable);
        }

        public void Configure(EntityTypeBuilder<ApplicationUserReadModel> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .HasMany(u => u.DirectoryTabs)
                .WithOne(d => d.Owner);

            builder.ToTable(TableNames.ApplicationUserTable);
        }
    }
}
