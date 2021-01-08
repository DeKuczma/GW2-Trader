using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BaseModels.Migrations
{
    public partial class AddedRecipeCreationPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Items_ItemId",
                table: "Listings");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Listings",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RecipePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Items = table.Column<int>(type: "integer", nullable: false),
                    CreationPriceBuyNow = table.Column<int>(type: "integer", nullable: false),
                    CreationPriceBuyOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipePrices_Items_Items",
                        column: x => x.Items,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpdateTimees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateTimees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipePrices_Items",
                table: "RecipePrices",
                column: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Items_ItemId",
                table: "Listings",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Items_ItemId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "RecipePrices");

            migrationBuilder.DropTable(
                name: "UpdateTimees");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Listings",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Items_ItemId",
                table: "Listings",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
