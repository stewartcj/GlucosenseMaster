using Microsoft.EntityFrameworkCore.Migrations;

namespace GlucoSmart.Data.Migrations
{
    public partial class ExerciseEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Minutes = table.Column<int>(nullable: false),
                    Exercise = table.Column<int>(nullable: false),
                    Intensity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseEntry", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseEntry");
        }
    }
}
