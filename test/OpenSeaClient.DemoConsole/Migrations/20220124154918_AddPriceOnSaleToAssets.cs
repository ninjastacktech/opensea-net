using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenSeaClient.DemoConsole.Migrations
{
    public partial class AddPriceOnSaleToAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                table: "Assets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Assets",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnSale",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Assets");
        }
    }
}
