using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministrativeService.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministrationPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timeframe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrationPrices", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministrationPrices");
        }
    }
}
