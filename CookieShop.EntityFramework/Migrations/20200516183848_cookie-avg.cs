using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieShop.EntityFramework.Migrations
{
    public partial class cookieavg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Accounts_AccountId",
                table: "CookieRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Users_UserId",
                table: "CookieRatings");

            migrationBuilder.DropIndex(
                name: "IX_CookieRatings_AccountId",
                table: "CookieRatings");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "CookieRatings");

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRatings_Accounts_UserId",
                table: "CookieRatings",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Accounts_UserId",
                table: "CookieRatings");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "CookieRatings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CookieRatings_AccountId",
                table: "CookieRatings",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRatings_Accounts_AccountId",
                table: "CookieRatings",
                column: "AccountId",
                principalTable: "Accounts",
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
    }
}
