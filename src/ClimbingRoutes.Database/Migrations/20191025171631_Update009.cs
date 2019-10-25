using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingRoutes.Database.Migrations
{
    public partial class Update009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplineId",
                table: "Grades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_DisciplineId",
                table: "Grades",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Disciplines_DisciplineId",
                table: "Grades",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "DisciplineId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Disciplines_DisciplineId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_DisciplineId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                table: "Grades");
        }
    }
}
