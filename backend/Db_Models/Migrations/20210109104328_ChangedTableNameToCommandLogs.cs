using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BaseModels.Migrations
{
    public partial class ChangedTableNameToCommandLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpdateTimees");

            migrationBuilder.CreateTable(
                name: "CommandLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<int>(type: "integer", nullable: false),
                    Inserted = table.Column<int>(type: "integer", nullable: false),
                    CommandExecuted = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandLogs");

            migrationBuilder.CreateTable(
                name: "UpdateTimees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommandExecuted = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<int>(type: "integer", nullable: false),
                    Inserted = table.Column<int>(type: "integer", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateTimees", x => x.Id);
                });
        }
    }
}
