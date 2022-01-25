using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenSeaClient.DemoConsole.Migrations
{
    public partial class AddIsProcessedToAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Assets",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Assets");
        }
    }
}
