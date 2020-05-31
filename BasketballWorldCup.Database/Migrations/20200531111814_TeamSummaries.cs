using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballWorldCup.Database.Migrations
{
    public partial class TeamSummaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    GroupId = table.Column<int>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Loses = table.Column<int>(nullable: false),
                    PointsForSum = table.Column<int>(nullable: false),
                    PointsAgainstSum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamSummaries_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamSummaries_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamSummaries_GroupId",
                table: "TeamSummaries",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamSummaries_TeamId",
                table: "TeamSummaries",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamSummaries");
        }
    }
}
