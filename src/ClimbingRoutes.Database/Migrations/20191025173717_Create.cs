using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingRoutes.Database.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crag",
                columns: table => new
                {
                    CragId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crag", x => x.CragId);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.DisciplineId);
                });

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

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    StyleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.StyleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UserId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    DisciplineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GradeId = table.Column<int>(nullable: false),
                    CragId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Routes_Crag_CragId",
                        column: x => x.CragId,
                        principalTable: "Crag",
                        principalColumn: "CragId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ascents",
                columns: table => new
                {
                    AscentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ascents", x => x.AscentId);
                    table.ForeignKey(
                        name: "FK_Ascents_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ascents_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ascents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Crag",
                columns: new[] { "CragId", "Name" },
                values: new object[,]
                {
                    { 1, "Balmashanner" },
                    { 2, "Ley Quarry" },
                    { 3, "Rod Rocks" }
                });

            migrationBuilder.InsertData(
                table: "Discipline",
                columns: new[] { "DisciplineId", "Description" },
                values: new object[,]
                {
                    { 1, "Sport" },
                    { 2, "Trad" },
                    { 3, "Bouldering" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "StyleId", "Description" },
                values: new object[,]
                {
                    { 1, "On Sight" },
                    { 2, "Worked" },
                    { 3, "Dogged" },
                    { 4, "Fail" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "UserId1" },
                values: new object[,]
                {
                    { 1, "123@456.com", "Andy", null },
                    { 2, "789@456.com", "Keith", null },
                    { 3, "legend_of@456.com", "Zorro", null }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "Description", "DisciplineId" },
                values: new object[,]
                {
                    { 1, "7a", 1 },
                    { 2, "7b", 1 },
                    { 3, "7c", 1 },
                    { 4, "E1", 2 },
                    { 5, "f7a", 3 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "CragId", "GradeId", "Name" },
                values: new object[,]
                {
                    { 2, 2, 1, "Nirvana" },
                    { 4, 1, 1, "Le Bon Vacance" },
                    { 1, 1, 2, "Savage Amusement" },
                    { 3, 3, 3, "Sultan" }
                });

            migrationBuilder.InsertData(
                table: "Ascents",
                columns: new[] { "AscentId", "Date", "RouteId", "StyleId", "UserId" },
                values: new object[,]
                {
                    { 3, new DateTime(2015, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 1 },
                    { 2, new DateTime(2011, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 1 },
                    { 1, new DateTime(2015, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 },
                    { 4, new DateTime(2015, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ascents_RouteId",
                table: "Ascents",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ascents_StyleId",
                table: "Ascents",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ascents_UserId",
                table: "Ascents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_DisciplineId",
                table: "Grades",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CragId",
                table: "Routes",
                column: "CragId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_GradeId",
                table: "Routes",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId1",
                table: "Users",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ascents");

            migrationBuilder.DropTable(
                name: "Partnerships");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Crag");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Discipline");
        }
    }
}
