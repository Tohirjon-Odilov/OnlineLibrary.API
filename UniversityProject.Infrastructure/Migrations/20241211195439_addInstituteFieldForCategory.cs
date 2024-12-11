using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addInstituteFieldForCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_ApplicationUserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ApplicationUserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "IsInstituteLiterature",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInstituteLiterature",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ApplicationUserId",
                table: "Books",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_ApplicationUserId",
                table: "Books",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
