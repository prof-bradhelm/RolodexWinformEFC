using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RolodexWinformEFC.Migrations
{
    public partial class RolodexInitialBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rolodex",
                columns: table => new
                {
                    RolodexEntryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(nullable: true),
                    FirstNameMI = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolodex", x => x.RolodexEntryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rolodex");
        }
    }
}
