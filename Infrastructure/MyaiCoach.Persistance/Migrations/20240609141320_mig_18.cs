using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyaiCoach.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GlutenInTolerance",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LactoseInTolerance",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NutritionDuration",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NutritionGoal",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Vegan",
                table: "AspNetUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutDayCount",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutDuration",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutLevel",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutType",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GlutenInTolerance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LactoseInTolerance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NutritionDuration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NutritionGoal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Vegan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkoutDayCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkoutDuration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkoutLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkoutType",
                table: "AspNetUsers");
        }
    }
}
