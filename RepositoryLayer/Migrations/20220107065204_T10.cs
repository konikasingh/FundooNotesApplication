using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class T10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modifiedat",
                table: "UserTable",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "Createat",
                table: "UserTable",
                newName: "CreateAt");

            migrationBuilder.CreateTable(
                name: "CollaborateTable",
                columns: table => new
                {
                    CollaborateId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderEmail = table.Column<string>(nullable: true),
                    ReceiverEmail = table.Column<string>(nullable: true),
                    NotesId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaborateTable", x => x.CollaborateId);
                    table.ForeignKey(
                        name: "FK_CollaborateTable_NotesTable_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NotesTable",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaborateTable_NotesId",
                table: "CollaborateTable",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaborateTable");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "UserTable",
                newName: "Modifiedat");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "UserTable",
                newName: "Createat");
        }
    }
}
