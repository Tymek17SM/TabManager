using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                schema: "tabmanager",
                table: "DirectoryTabs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                schema: "tabmanager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoryTabs_OwnerId",
                schema: "tabmanager",
                table: "DirectoryTabs",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoryTabs_ApplicationUsers_OwnerId",
                schema: "tabmanager",
                table: "DirectoryTabs",
                column: "OwnerId",
                principalSchema: "tabmanager",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectoryTabs_ApplicationUsers_OwnerId",
                schema: "tabmanager",
                table: "DirectoryTabs");

            migrationBuilder.DropTable(
                name: "ApplicationUsers",
                schema: "tabmanager");

            migrationBuilder.DropIndex(
                name: "IX_DirectoryTabs_OwnerId",
                schema: "tabmanager",
                table: "DirectoryTabs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "tabmanager",
                table: "DirectoryTabs");
        }
    }
}
