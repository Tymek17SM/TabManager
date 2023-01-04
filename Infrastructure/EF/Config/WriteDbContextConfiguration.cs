using Domain.Entities;
using Domain.ValueObjects.Directory;
using Domain.ValueObjects.Tab;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EF.Config
{
    internal sealed class WriteDbContextConfiguration :
        IEntityTypeConfiguration<Tab>,
        IEntityTypeConfiguration<DirectoryTab>
    {
        public void Configure(EntityTypeBuilder<Tab> builder)
        {
            var tabNameConverter = new ValueConverter<TabName, string>(
                tabName => tabName.Value, 
                value => new TabName(value)
                );

            var tabLinkConverter = new ValueConverter<TabLink, string>(
                tabLink => tabLink.Value,
                value => new TabLink(value)
                );

            var tabDescriptionConvert = new ValueConverter<TabDescription, string>(
                tabDescription => tabDescription.Value,
                value => new TabDescription(value)
                );

            var tabDirectoryTabIdConvert = new ValueConverter<DirectoryTabId, Guid>(
                tabDirTabId => tabDirTabId.Value,
                value => new DirectoryTabId(value)
                );

            builder.HasKey(tab => tab.Id);

            builder
                .Property(tab => tab.Id)
                .HasConversion(tabId => tabId.Value, guid => new TabId(guid));

            builder
                .Property(typeof(TabName), "_name")
                .HasConversion(tabNameConverter)
                .HasColumnName("Name");

            builder
                .Property(typeof(TabLink), "_link")
                .HasConversion(tabLinkConverter)
                .HasColumnName("Link");

            builder
                .Property(typeof(TabDescription), "_description")
                .HasConversion(tabDescriptionConvert)
                .HasColumnName("Description");

            builder
                .Property(typeof(DateTime), "_created")
                .HasColumnName("Created");

            builder
                .Property(typeof(string), "_createdBy")
                .HasColumnName("CreatedBy");

            builder
                .Property(typeof(DirectoryTabId), "_directoryTabId")
                .HasConversion(tabDirectoryTabIdConvert)
                .HasColumnName("DirectoryTabReadModelId");

            builder
                .HasOne(typeof(DirectoryTab), "_directoryTab")
                .WithMany("_tabs");

            builder.ToTable(TableNames.TabTable);
        }

        public void Configure(EntityTypeBuilder<DirectoryTab> builder)
        {
            var directoryTabNameConverter = new ValueConverter<DirectoryTabName, string>(
                dirTabName => dirTabName.Value,
                value => new DirectoryTabName(value)
                );

            var directoryTabIdConverter = new ValueConverter<DirectoryTabId, Guid>(
                dirTabId => dirTabId.Value,
                value => new DirectoryTabId(value)
                );

            builder.HasKey(dir => dir.Id);

            builder
                .Property(dir => dir.Id)
                .HasConversion(dirId => dirId.Value, guid => new DirectoryTabId(guid));

            builder
                .Property(typeof(DirectoryTabName), "_directoryName")
                .HasConversion(directoryTabNameConverter)
                .HasColumnName("Name");

            builder
                .Property(typeof(bool), "_mainDirectory")
                .HasColumnName("MainDirectory");

            builder
                .Property(typeof(DirectoryTabId), "_superiorDirectoryId")
                .HasConversion(directoryTabIdConverter)
                .HasColumnName("SuperiorDirectoryId")
                .IsRequired(false);

            builder
                .Property(typeof(DirectoryTabId), "_subordinateDirectoryId")
                .HasConversion(directoryTabIdConverter)
                .HasColumnName("SubordinateDirectoryId")
                .IsRequired(false);

            builder
                .Property(typeof(DateTime), "_created")
                .HasColumnName("Created");

            builder
                .Property(typeof(string), "_createdBy")
                .HasColumnName("CreatedBy");

            //builder
            //    .HasMany(typeof(Tab), "_tabs");

            builder.ToTable(TableNames.DirectoryTabTable);
        }
    }
}
