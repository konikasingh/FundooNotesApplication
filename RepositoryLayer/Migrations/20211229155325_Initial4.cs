using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NotesTable_Id",
                table: "NotesTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesTable_UserTable_Id",
                table: "NotesTable",
                column: "Id",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesTable_UserTable_Id",
                table: "NotesTable");

            migrationBuilder.DropIndex(
                name: "IX_NotesTable_Id",
                table: "NotesTable");
        }
    }
}
