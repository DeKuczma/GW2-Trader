using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseModels.Migrations
{
    public partial class ChangedUpdateTimeTableToCommandExecutionLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommandExecuted",
                table: "UpdateTimees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Deleted",
                table: "UpdateTimees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inserted",
                table: "UpdateTimees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommandExecuted",
                table: "UpdateTimees");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "UpdateTimees");

            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "UpdateTimees");
        }
    }
}
