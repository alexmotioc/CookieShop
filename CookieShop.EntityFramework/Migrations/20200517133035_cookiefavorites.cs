using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieShop.EntityFramework.Migrations
{
    public partial class cookiefavorites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Accounts_UserId",
                table: "CookieRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Cookies_Accounts_AccountId",
                table: "Cookies");

            migrationBuilder.DropIndex(
                name: "IX_Cookies_AccountId",
                table: "Cookies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieRatings",
                table: "CookieRatings");

            migrationBuilder.DropIndex(
                name: "IX_CookieRatings_UserId",
                table: "CookieRatings");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Cookies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CookieRatings");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CookieRatings",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "CookieID",
                table: "CookieRatings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieRatings",
                table: "CookieRatings",
                column: "CookieID");

            migrationBuilder.CreateTable(
                name: "FavoriteCookies",
                columns: table => new
                {
                    CookieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookieId = table.Column<int>(nullable: true),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCookies", x => x.CookieID);
                    table.ForeignKey(
                        name: "FK_FavoriteCookies_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteCookies_Cookies_CookieId",
                        column: x => x.CookieId,
                        principalTable: "Cookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookieRatings_Id",
                table: "CookieRatings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCookies_AccountId",
                table: "FavoriteCookies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCookies_CookieId",
                table: "FavoriteCookies",
                column: "CookieId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRatings_Accounts_Id",
                table: "CookieRatings",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookieRatings_Accounts_Id",
                table: "CookieRatings");

            migrationBuilder.DropTable(
                name: "FavoriteCookies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieRatings",
                table: "CookieRatings");

            migrationBuilder.DropIndex(
                name: "IX_CookieRatings_Id",
                table: "CookieRatings");

            migrationBuilder.DropColumn(
                name: "CookieID",
                table: "CookieRatings");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Cookies",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CookieRatings",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CookieRatings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieRatings",
                table: "CookieRatings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cookies_AccountId",
                table: "Cookies",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CookieRatings_UserId",
                table: "CookieRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookieRatings_Accounts_UserId",
                table: "CookieRatings",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cookies_Accounts_AccountId",
                table: "Cookies",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
