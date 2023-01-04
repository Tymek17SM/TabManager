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
        IEntityTypeConfiguration<DirectoryTabReadModel>
    {
        public void Configure(EntityTypeBuilder<TabReadModel> builder)
        {
            builder.HasKey(tab => tab.Id);

            builder
                .Property<Guid>("DirectoryTabReadModelId");

            builder
                .HasOne(tab => tab.DirectoryTabReadModel)
                .WithMany(dir => dir.TabReadModels)
                .HasForeignKey("DirectoryTabReadModelId")
                .HasConstraintName("Test_Directory_Tab_Id");

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
                .WithMany()
                .HasForeignKey("SuperiorDirectoryId")
                .HasPrincipalKey(dir => dir.Id);

            builder
                .Property<Guid?>("SubordinateDirectoryId")
                .IsRequired(false);

            builder
                .HasOne(dir => dir.SubordinateDirectory)
                .WithMany()
                .HasForeignKey("SubordinateDirectoryId")
                .HasPrincipalKey(dir => dir.Id);

            builder
                .HasMany(dir => dir.TabReadModels)
                .WithOne(tab => tab.DirectoryTabReadModel);

            builder.ToTable(TableNames.DirectoryTabTable);
        }
    }
}
