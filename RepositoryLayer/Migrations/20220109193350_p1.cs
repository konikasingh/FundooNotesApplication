using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class p1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Createat",
                table: "UserTable");

            migrationBuilder.DropColumn(
                name: "Modifiedat",
                table: "UserTable");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatAt",
                table: "UserTable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifidAt",
                table: "UserTable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatAt",
                table: "UserTable");

            migrationBuilder.DropColumn(
                name: "ModifidAt",
                table: "UserTable");

            migrationBuilder.AddColumn<DateTime>(
                name: "Createat",
                table: "UserTable",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifiedat",
                table: "UserTable",
                type: "datetime2",
                nullable: true);
        }
    }
}
