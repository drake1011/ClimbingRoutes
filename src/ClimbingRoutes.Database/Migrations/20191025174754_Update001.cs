using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingRoutes.Database.Migrations
{
    public partial class Update001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Crag",
                columns: new[] { "CragId", "Name" },
                values: new object[] { 4, "Clashrodney" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Description", "DisciplineId" },
                values: new object[] { 6, "VS", 2 });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "CragId", "GradeId", "Name" },
                values: new object[] { 5, 4, 6, "Serpent" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Routes",
                keyColumn: "RouteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Crag",
                keyColumn: "CragId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "GradeId",
                keyValue: 6);
        }
    }
}
