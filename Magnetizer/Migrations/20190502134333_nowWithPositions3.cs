using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Magnetizer.Migrations
{
    public partial class nowWithPositions3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosX",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PosY",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    x = table.Column<string>(nullable: true),
                    y = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_LocationId",
                table: "Product",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Location_LocationId",
                table: "Product",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Location_LocationId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Product_LocationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "PosX",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosY",
                table: "Product",
                nullable: true);
        }
    }
}
