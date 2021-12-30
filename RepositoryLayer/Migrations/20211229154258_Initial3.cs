using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesTable_UserTable_Id",
                table: "NotesTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotesTable",
                table: "NotesTable");

            migrationBuilder.AddColumn<long>(
                name: "NotesId",
                table: "NotesTable",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotesTable",
                table: "NotesTable",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotesTable",
                table: "NotesTable");

            migrationBuilder.DropColumn(
                name: "NotesId",
                table: "NotesTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotesTable",
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
    }
}
