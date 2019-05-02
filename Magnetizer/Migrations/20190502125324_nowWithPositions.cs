using Microsoft.EntityFrameworkCore.Migrations;

namespace Magnetizer.Migrations
{
    public partial class nowWithPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PosX",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosY",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Product");
        }
    }
}
