using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseModels.Migrations
{
    public partial class AddedRecipeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Recipes_OutputItemId",
                table: "Recipes",
                column: "OutputItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Items_OutputItemId",
                table: "Recipes",
                column: "OutputItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Items_OutputItemId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_OutputItemId",
                table: "Recipes");
        }
    }
}
