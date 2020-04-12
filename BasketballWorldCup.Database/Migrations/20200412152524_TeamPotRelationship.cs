using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballWorldCup.Database.Migrations
{
    public partial class TeamPotRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Pots_PotId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PotId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PotId",
                table: "Teams");

            migrationBuilder.CreateTable(
                name: "TeamPot",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    PotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPot", x => new { x.TeamId, x.PotId });
                    table.ForeignKey(
                        name: "FK_TeamPot_Pots_PotId",
                        column: x => x.PotId,
                        principalTable: "Pots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPot_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamPot_PotId",
                table: "TeamPot",
                column: "PotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamPot");

            migrationBuilder.AddColumn<int>(
                name: "PotId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PotId",
                table: "Teams",
                column: "PotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Pots_PotId",
                table: "Teams",
                column: "PotId",
                principalTable: "Pots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
