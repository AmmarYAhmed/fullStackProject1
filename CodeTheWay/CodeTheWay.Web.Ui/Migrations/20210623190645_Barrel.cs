using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTheWay.Web.Ui.Migrations
{
    public partial class Barrel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barrels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Radius = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Contents = table.Column<int>(nullable: false),
                    CurrentLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barrels");
        }
    }
}
