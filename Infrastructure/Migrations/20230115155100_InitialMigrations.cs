using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tabmanager");

            migrationBuilder.CreateTable(
                name: "DirectoryTabs",
                schema: "tabmanager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainDirectory = table.Column<bool>(type: "bit", nullable: false),
                    SuperiorDirectoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoryTabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectoryTabs_DirectoryTabs_SuperiorDirectoryId",
                        column: x => x.SuperiorDirectoryId,
                        principalSchema: "tabmanager",
                        principalTable: "DirectoryTabs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tabs",
                schema: "tabmanager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectoryTabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabs_DirectoryTabs_DirectoryTabId",
                        column: x => x.DirectoryTabId,
                        principalSchema: "tabmanager",
                        principalTable: "DirectoryTabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryTabs_SuperiorDirectoryId",
                schema: "tabmanager",
                table: "DirectoryTabs",
                column: "SuperiorDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_DirectoryTabId",
                schema: "tabmanager",
                table: "Tabs",
                column: "DirectoryTabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabs",
                schema: "tabmanager");

            migrationBuilder.DropTable(
                name: "DirectoryTabs",
                schema: "tabmanager");
        }
    }
}
