using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BaseModels.Migrations
{
    public partial class AddedRecipeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    OutputItemId = table.Column<int>(type: "integer", nullable: false),
                    OutputItemCount = table.Column<int>(type: "integer", nullable: false),
                    TimeToCraftMs = table.Column<int>(type: "integer", nullable: false),
                    Disciplines = table.Column<string>(type: "text", nullable: false),
                    MinRating = table.Column<int>(type: "integer", nullable: false),
                    Flags = table.Column<string>(type: "text", nullable: true),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    GuildIngredients = table.Column<string>(type: "text", nullable: true),
                    OutputUpgradeId = table.Column<int>(type: "integer", nullable: false),
                    ChatLink = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
