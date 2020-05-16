using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieShop.EntityFramework.Migrations
{
    public partial class cookierating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Cookies",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CookieRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookieId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookieRating_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CookieRating_Cookies_CookieId",
                        column: x => x.CookieId,
                        principalTable: "Cookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CookieRating_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cookies_AccountId",
                table: "Cookies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CookieRating_AccountId",
                table: "CookieRating",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CookieRating_CookieId",
                table: "CookieRating",
                column: "CookieId");

            migrationBuilder.CreateIndex(
                name: "IX_CookieRating_UserId",
                table: "CookieRating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cookies_Accounts_AccountId",
                table: "Cookies",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cookies_Accounts_AccountId",
                table: "Cookies");

            migrationBuilder.DropTable(
                name: "CookieRating");

            migrationBuilder.DropIndex(
                name: "IX_Cookies_AccountId",
                table: "Cookies");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Cookies");
        }
    }
}
