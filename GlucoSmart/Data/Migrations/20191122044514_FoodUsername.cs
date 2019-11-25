using Microsoft.EntityFrameworkCore.Migrations;

namespace GlucoSmart.Data.Migrations
{
    public partial class FoodUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "FoodEntry",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "FoodEntry");
        }
    }
}
