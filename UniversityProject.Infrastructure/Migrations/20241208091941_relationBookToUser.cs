using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationBookToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Countries_CountryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ApplicationUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "ApplcationUserId",
                table: "Books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_ApplcationUserId",
                table: "Books",
                column: "ApplcationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Countries_CountryId",
                table: "Books",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_ApplcationUserId",
                table: "Books",
                column: "ApplcationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ApplicationUserId",
                table: "Reports",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Countries_CountryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_ApplcationUserId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_ApplicationUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_ApplicationUserId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Books_ApplcationUserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ApplcationUserId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Countries_CountryId",
                table: "Authors",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Countries_CountryId",
                table: "Books",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_ApplicationUserId",
                table: "Events",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_ApplicationUserId",
                table: "Reports",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
