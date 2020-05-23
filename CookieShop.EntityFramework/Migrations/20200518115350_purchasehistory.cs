using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieShop.EntityFramework.Migrations
{
    public partial class purchasehistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTransactions_Accounts_AccountId",
                table: "AssetTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetTransactions_Cookies_CookieId",
                table: "AssetTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetTransactions",
                table: "AssetTransactions");

            migrationBuilder.RenameTable(
                name: "AssetTransactions",
                newName: "PurchaseHistory");

            migrationBuilder.RenameIndex(
                name: "IX_AssetTransactions_CookieId",
                table: "PurchaseHistory",
                newName: "IX_PurchaseHistory_CookieId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetTransactions_AccountId",
                table: "PurchaseHistory",
                newName: "IX_PurchaseHistory_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseHistory",
                table: "PurchaseHistory",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistory_Accounts_AccountId",
                table: "PurchaseHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseHistory_Cookies_CookieId",
                table: "PurchaseHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseHistory",
                table: "PurchaseHistory");

            migrationBuilder.RenameTable(
                name: "PurchaseHistory",
                newName: "AssetTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseHistory_CookieId",
                table: "AssetTransactions",
                newName: "IX_AssetTransactions_CookieId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseHistory_AccountId",
                table: "AssetTransactions",
                newName: "IX_AssetTransactions_AccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetTransactions",
                table: "AssetTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTransactions_Accounts_AccountId",
                table: "AssetTransactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTransactions_Cookies_CookieId",
                table: "AssetTransactions",
                column: "CookieId",
                principalTable: "Cookies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
