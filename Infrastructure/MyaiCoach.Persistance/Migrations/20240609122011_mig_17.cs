using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyaiCoach.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionDays_AspNetUsers_AppUserId",
                table: "NutritionDays");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionDays_AspNetUsers_AppUserId",
                table: "NutritionDays",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NutritionDays_AspNetUsers_AppUserId",
                table: "NutritionDays");

            migrationBuilder.AddForeignKey(
                name: "FK_NutritionDays_AspNetUsers_AppUserId",
                table: "NutritionDays",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
