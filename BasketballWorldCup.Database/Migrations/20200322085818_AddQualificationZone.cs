using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballWorldCup.Database.Migrations
{
    public partial class AddQualificationZone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualificationZone",
                table: "Teams",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QualificationZone",
                table: "Teams");
        }
    }
}
