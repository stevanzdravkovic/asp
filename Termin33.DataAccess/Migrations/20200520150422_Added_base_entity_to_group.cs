using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Termin33.DataAccess.Migrations
{
    public partial class Added_base_entity_to_group : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Groups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Groups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Groups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Groups");
        }
    }
}
