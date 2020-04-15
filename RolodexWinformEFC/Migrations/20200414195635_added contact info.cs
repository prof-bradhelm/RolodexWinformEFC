using Microsoft.EntityFrameworkCore.Migrations;

namespace RolodexWinformEFC.Migrations
{
    public partial class addedcontactinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    RolodexContactId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerRolodexEntryId = table.Column<int>(nullable: true),
                    HowToContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.RolodexContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_Rolodex_OwnerRolodexEntryId",
                        column: x => x.OwnerRolodexEntryId,
                        principalTable: "Rolodex",
                        principalColumn: "RolodexEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerRolodexEntryId",
                table: "Contacts",
                column: "OwnerRolodexEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
