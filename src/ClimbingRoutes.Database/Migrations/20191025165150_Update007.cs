using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingRoutes.Database.Migrations
{
    public partial class Update007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Partners_PartnerId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Users_PartnerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Partnerships",
                columns: table => new
                {
                    PartnershipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PartnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partnerships", x => x.PartnershipId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partnerships");

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    PartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.PartnerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PartnerId",
                table: "Users",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Partners_PartnerId",
                table: "Users",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "PartnerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
