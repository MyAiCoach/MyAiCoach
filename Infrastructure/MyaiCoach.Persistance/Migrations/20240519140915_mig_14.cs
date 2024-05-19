using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyaiCoach.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Carbonhydrate = table.Column<decimal>(type: "numeric", nullable: false),
                    Protein = table.Column<decimal>(type: "numeric", nullable: false),
                    Calory = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NutritionDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    NutritionSessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoesItWorks = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionDays_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    GramId = table.Column<Guid>(type: "uuid", nullable: false),
                    NutritionDayId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionSessions_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutritionSessions_Grams_GramId",
                        column: x => x.GramId,
                        principalTable: "Grams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionDayNutritionSession",
                columns: table => new
                {
                    NutritionDaysId = table.Column<Guid>(type: "uuid", nullable: false),
                    NutritionSessionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionDayNutritionSession", x => new { x.NutritionDaysId, x.NutritionSessionsId });
                    table.ForeignKey(
                        name: "FK_NutritionDayNutritionSession_NutritionDays_NutritionDaysId",
                        column: x => x.NutritionDaysId,
                        principalTable: "NutritionDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NutritionDayNutritionSession_NutritionSessions_NutritionSes~",
                        column: x => x.NutritionSessionsId,
                        principalTable: "NutritionSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NutritionDayNutritionSession_NutritionSessionsId",
                table: "NutritionDayNutritionSession",
                column: "NutritionSessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionDays_AppUserId",
                table: "NutritionDays",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionSessions_FoodId",
                table: "NutritionSessions",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionSessions_GramId",
                table: "NutritionSessions",
                column: "GramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NutritionDayNutritionSession");

            migrationBuilder.DropTable(
                name: "NutritionDays");

            migrationBuilder.DropTable(
                name: "NutritionSessions");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Grams");
        }
    }
}
