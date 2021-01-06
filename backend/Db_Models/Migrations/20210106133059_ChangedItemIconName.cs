using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseModels.Migrations
{
    public partial class ChangedItemIconName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconURL",
                table: "Items",
                newName: "Icon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Items",
                newName: "IconURL");
        }
    }
}
