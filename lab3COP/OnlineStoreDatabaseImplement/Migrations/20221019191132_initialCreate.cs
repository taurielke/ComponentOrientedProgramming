using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStoreDatabaseImplement.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinationCities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationCities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: false),
                    DestinationCity = table.Column<string>(nullable: false),
                    DestinationDate = table.Column<DateTime>(nullable: true),
                    Track1 = table.Column<string>(nullable: true),
                    Track2 = table.Column<string>(nullable: true),
                    Track3 = table.Column<string>(nullable: true),
                    Track4 = table.Column<string>(nullable: true),
                    Track5 = table.Column<string>(nullable: true),
                    Track6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationCities");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
