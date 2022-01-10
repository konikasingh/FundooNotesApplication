using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class p3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaboratorTable",
                table: "CollaboratorTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaboratorTable",
                table: "CollaboratorTable",
                column: "CollaboratorId");

            migrationBuilder.CreateTable(
                name: "LableTable",
                columns: table => new
                {
                    LableId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotesId = table.Column<long>(nullable: true),
                    Id = table.Column<long>(nullable: false),
                    LableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LableTable", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_LableTable_UserTable_Id",
                        column: x => x.Id,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LableTable_NotesTable_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NotesTable",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LableTable_Id",
                table: "LableTable",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LableTable_NotesId",
                table: "LableTable",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LableTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaboratorTable",
                table: "CollaboratorTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaboratorTable",
                table: "CollaboratorTable",
                columns: new[] { "CollaboratorId", "NotesId", "Id" });
        }
    }
}
