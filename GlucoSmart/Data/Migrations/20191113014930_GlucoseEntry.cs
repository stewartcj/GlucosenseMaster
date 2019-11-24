using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlucoSmart.Data.Migrations
{
    public partial class GlucoseEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlucoseEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    BloodSugar = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Reading = table.Column<int>(nullable: false),
                    Meal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlucoseEntry", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlucoseEntry");
        }
    }
}
