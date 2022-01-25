using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenSeaClient.DemoConsole.Migrations
{
    public partial class AddAccumulatedToAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Accumulated",
                table: "Assets",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accumulated",
                table: "Assets");
        }
    }
}
