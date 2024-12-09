using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationManyToManyBookUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_ApplcationUserId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ApplcationUserId",
                table: "Books",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_ApplcationUserId",
                table: "Books",
                newName: "IX_Books_ApplicationUserId");

            migrationBuilder.CreateTable(
                name: "UserBooks",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooks", x => new { x.ApplicationUserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_UserBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBooks_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_BookId",
                table: "UserBooks",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_ApplicationUserId",
                table: "Books",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_ApplicationUserId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "UserBooks");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Books",
                newName: "ApplcationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_ApplicationUserId",
                table: "Books",
                newName: "IX_Books_ApplcationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_ApplcationUserId",
                table: "Books",
                column: "ApplcationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
