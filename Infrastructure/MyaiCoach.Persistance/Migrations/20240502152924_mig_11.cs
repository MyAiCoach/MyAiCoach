using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyaiCoach.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_WorkoutDays_WorkoutDayId",
                table: "WorkoutSessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutDayId",
                table: "WorkoutSessions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutDays_WorkoutDayId",
                table: "WorkoutSessions",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_WorkoutDays_WorkoutDayId",
                table: "WorkoutSessions");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutDayId",
                table: "WorkoutSessions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutDays_WorkoutDayId",
                table: "WorkoutSessions",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
