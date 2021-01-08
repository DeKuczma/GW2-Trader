using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseModels.Migrations
{
    public partial class FixingNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipePrices_Items_Items",
                table: "RecipePrices");

            migrationBuilder.RenameColumn(
                name: "Items",
                table: "RecipePrices",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipePrices_Items",
                table: "RecipePrices",
                newName: "IX_RecipePrices_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipePrices_Items_ItemId",
                table: "RecipePrices",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipePrices_Items_ItemId",
                table: "RecipePrices");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "RecipePrices",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_RecipePrices_ItemId",
                table: "RecipePrices",
                newName: "IX_RecipePrices_Items");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipePrices_Items_Items",
                table: "RecipePrices",
                column: "Items",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
