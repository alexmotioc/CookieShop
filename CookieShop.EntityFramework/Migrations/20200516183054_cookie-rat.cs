using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieShop.EntityFramework.Migrations
{
    public partial class cookierat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookieRating_Accounts_AccountId",
                table: "CookieRating");

            migrationBuilder.DropForeignKey(
                name: "FK_CookieRating_Cookies_CookieId",
                table: "CookieRating");

            migrationBuilder.DropForeignKey(
                name: "FK_CookieRating_Users_UserId",
                table: "CookieRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieRating",
                table: "CookieRating");

            migrationBuilder.RenameTable(
                name: "CookieRating",
                newName: "CookieRatings");

            migrationBuilder.RenameIndex(
                name: "IX_CookieRating_UserId",
                table: "CookieRatings",
                newName: "IX_CookieRatings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CookieRating_CookieId",
                table: "CookieRatings",
                newName: "IX_CookieRatings_CookieId");

            migrationBuilder.RenameIndex(
                name: "IX_CookieRating_AccountId",
                table: "CookieRatings",
                newName: "IX_CookieRatings_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieRatings",
                table: "CookieRatings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRatings_Accounts_AccountId",
                table: "CookieRatings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRatings_Cookies_CookieId",
                table: "CookieRatings",
                column: "CookieId",
                principalTable: "Cookies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRatings_Users_UserId",
                table: "CookieRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Accounts_AccountId",
                table: "CookieRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Cookies_CookieId",
                table: "CookieRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Users_UserId",
                table: "CookieRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieRatings",
                table: "CookieRatings");

            migrationBuilder.RenameTable(
                name: "CookieRatings",
                newName: "CookieRating");

            migrationBuilder.RenameIndex(
                name: "IX_CookieRatings_UserId",
                table: "CookieRating",
                newName: "IX_CookieRating_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CookieRatings_CookieId",
                table: "CookieRating",
                newName: "IX_CookieRating_CookieId");

            migrationBuilder.RenameIndex(
                name: "IX_CookieRatings_AccountId",
                table: "CookieRating",
                newName: "IX_CookieRating_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieRating",
                table: "CookieRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRating_Accounts_AccountId",
                table: "CookieRating",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRating_Cookies_CookieId",
                table: "CookieRating",
                column: "CookieId",
                principalTable: "Cookies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRating_Users_UserId",
                table: "CookieRating",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
