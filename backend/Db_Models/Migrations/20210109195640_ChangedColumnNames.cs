using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseModels.Migrations
{
    public partial class ChangedColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellListing",
                table: "Listings",
                newName: "Sells");

            migrationBuilder.RenameColumn(
                name: "BuyListing",
                table: "Listings",
                newName: "Buys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sells",
                table: "Listings",
                newName: "SellListing");

            migrationBuilder.RenameColumn(
                name: "Buys",
                table: "Listings",
                newName: "BuyListing");
        }
    }
}
