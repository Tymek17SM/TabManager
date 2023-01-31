using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropOwnerToTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                schema: "tabmanager",
                table: "Tabs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_OwnerId",
                schema: "tabmanager",
                table: "Tabs",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_ApplicationUsers_OwnerId",
                schema: "tabmanager",
                table: "Tabs",
                column: "OwnerId",
                principalSchema: "tabmanager",
                principalTable: "ApplicationUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_ApplicationUsers_OwnerId",
                schema: "tabmanager",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_OwnerId",
                schema: "tabmanager",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "tabmanager",
                table: "Tabs");
        }
    }
}
