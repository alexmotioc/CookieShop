using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieShop.EntityFramework.Migrations
{
    public partial class purchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistory_Accounts_AccountId",
                table: "PurchaseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistory_Cookies_CookieId",
                table: "PurchaseHistory");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseHistory_CookieId",
                table: "PurchaseHistory");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PurchaseHistory");

            migrationBuilder.DropColumn(
                name: "CookieId",
                table: "PurchaseHistory");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "PurchaseHistory",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookieId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    PurchaseHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_Cookies_CookieId",
                        column: x => x.CookieId,
                        principalTable: "Cookies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseItem_PurchaseHistory_PurchaseHistoryId",
                        column: x => x.PurchaseHistoryId,
                        principalTable: "PurchaseHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_CookieId",
                table: "PurchaseItem",
                column: "CookieId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_PurchaseHistoryId",
                table: "PurchaseItem",
                column: "PurchaseHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistory_Accounts_AccountId",
                table: "PurchaseHistory",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistory_Accounts_AccountId",
                table: "PurchaseHistory");

            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "PurchaseHistory",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "PurchaseHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CookieId",
                table: "PurchaseHistory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseHistory_CookieId",
                table: "PurchaseHistory",
                column: "CookieId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistory_Accounts_AccountId",
                table: "PurchaseHistory",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseHistory_Cookies_CookieId",
                table: "PurchaseHistory",
                column: "CookieId",
                principalTable: "Cookies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
