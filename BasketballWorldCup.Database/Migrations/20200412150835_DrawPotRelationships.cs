using Microsoft.EntityFrameworkCore.Migrations;

namespace BasketballWorldCup.Database.Migrations
{
    public partial class DrawPotRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PotId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrawId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pots_Draws_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PotId",
                table: "Teams",
                column: "PotId");

            migrationBuilder.CreateIndex(
                name: "IX_Pots_DrawId",
                table: "Pots",
                column: "DrawId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Pots_PotId",
                table: "Teams",
                column: "PotId",
                principalTable: "Pots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Pots_PotId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Pots");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PotId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PotId",
                table: "Teams");
        }
    }
}
