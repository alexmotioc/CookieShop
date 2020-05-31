using Microsoft.EntityFrameworkCore.Migrations;

namespace CookieShop.EntityFramework.Migrations
{
    public partial class purchaseitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_Cookies_CookieId",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_PurchaseHistory_PurchaseHistoryId",
                table: "PurchaseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseItem",
                table: "PurchaseItem");

            migrationBuilder.RenameTable(
                name: "PurchaseItem",
                newName: "purchaseItems");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItem_PurchaseHistoryId",
                table: "purchaseItems",
                newName: "IX_purchaseItems_PurchaseHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItem_CookieId",
                table: "purchaseItems",
                newName: "IX_purchaseItems_CookieId");

            migrationBuilder.AlterColumn<int>(
                name: "CookieId",
                table: "purchaseItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchaseItems",
                table: "purchaseItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_Cookies_CookieId",
                table: "purchaseItems",
                column: "CookieId",
                principalTable: "Cookies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseItems_PurchaseHistory_PurchaseHistoryId",
                table: "purchaseItems",
                column: "PurchaseHistoryId",
                principalTable: "PurchaseHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_Cookies_CookieId",
                table: "purchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseItems_PurchaseHistory_PurchaseHistoryId",
                table: "purchaseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchaseItems",
                table: "purchaseItems");

            migrationBuilder.RenameTable(
                name: "purchaseItems",
                newName: "PurchaseItem");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_PurchaseHistoryId",
                table: "PurchaseItem",
                newName: "IX_PurchaseItem_PurchaseHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_purchaseItems_CookieId",
                table: "PurchaseItem",
                newName: "IX_PurchaseItem_CookieId");

            migrationBuilder.AlterColumn<int>(
                name: "CookieId",
                table: "PurchaseItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseItem",
                table: "PurchaseItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_Cookies_CookieId",
                table: "PurchaseItem",
                column: "CookieId",
                principalTable: "Cookies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_PurchaseHistory_PurchaseHistoryId",
                table: "PurchaseItem",
                column: "PurchaseHistoryId",
                principalTable: "PurchaseHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
