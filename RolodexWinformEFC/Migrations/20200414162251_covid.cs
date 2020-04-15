using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RolodexWinformEFC.Migrations
{
    public partial class covid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdmitDate",
                table: "Rolodex",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MRN",
                table: "Rolodex",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "Rolodex",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdmitDate",
                table: "Rolodex");

            migrationBuilder.DropColumn(
                name: "MRN",
                table: "Rolodex");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Rolodex");
        }
    }
}
