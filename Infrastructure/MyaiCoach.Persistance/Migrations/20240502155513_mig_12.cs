using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyaiCoach.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_WorkoutDays_WorkoutDayId",
                table: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_WorkoutDayId",
                table: "WorkoutSessions");

            migrationBuilder.RenameColumn(
                name: "WorkoutSessionsId",
                table: "WorkoutDays",
                newName: "WorkoutSessionId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutDayId",
                table: "WorkoutSessions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WorkoutDayWorkoutSession",
                columns: table => new
                {
                    WorkoutDaysId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutSessionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDayWorkoutSession", x => new { x.WorkoutDaysId, x.WorkoutSessionsId });
                    table.ForeignKey(
                        name: "FK_WorkoutDayWorkoutSession_WorkoutDays_WorkoutDaysId",
                        column: x => x.WorkoutDaysId,
                        principalTable: "WorkoutDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutDayWorkoutSession_WorkoutSessions_WorkoutSessionsId",
                        column: x => x.WorkoutSessionsId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayWorkoutSession_WorkoutSessionsId",
                table: "WorkoutDayWorkoutSession",
                column: "WorkoutSessionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutDayWorkoutSession");

            migrationBuilder.RenameColumn(
                name: "WorkoutSessionId",
                table: "WorkoutDays",
                newName: "WorkoutSessionsId");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkoutDayId",
                table: "WorkoutSessions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_WorkoutDayId",
                table: "WorkoutSessions",
                column: "WorkoutDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_WorkoutDays_WorkoutDayId",
                table: "WorkoutSessions",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id");
        }
    }
}
