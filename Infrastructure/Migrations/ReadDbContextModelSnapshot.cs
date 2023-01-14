﻿// <auto-generated />
using System;
using Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("tabmanager")
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EF.Models.DirectoryTabReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MainDirectory")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubordinateDirectoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SuperiorDirectoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubordinateDirectoryId");

                    b.HasIndex("SuperiorDirectoryId");

                    b.ToTable("DirectoryTabs", "tabmanager");
                });

            modelBuilder.Entity("Infrastructure.EF.Models.TabReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DirectoryTabId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DirectoryTabId");

                    b.ToTable("Tabs", "tabmanager");
                });

            modelBuilder.Entity("Infrastructure.EF.Models.DirectoryTabReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.Models.DirectoryTabReadModel", "SubordinateDirectory")
                        .WithMany()
                        .HasForeignKey("SubordinateDirectoryId");

                    b.HasOne("Infrastructure.EF.Models.DirectoryTabReadModel", "SuperiorDirectory")
                        .WithMany()
                        .HasForeignKey("SuperiorDirectoryId");

                    b.Navigation("SubordinateDirectory");

                    b.Navigation("SuperiorDirectory");
                });

            modelBuilder.Entity("Infrastructure.EF.Models.TabReadModel", b =>
                {
                    b.HasOne("Infrastructure.EF.Models.DirectoryTabReadModel", "DirectoryTab")
                        .WithMany("Tabs")
                        .HasForeignKey("DirectoryTabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DirectoryTab");
                });

            modelBuilder.Entity("Infrastructure.EF.Models.DirectoryTabReadModel", b =>
                {
                    b.Navigation("Tabs");
                });
#pragma warning restore 612, 618
        }
    }
}
