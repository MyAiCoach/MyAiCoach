using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyaiCoach.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutSessionsIds",
                table: "WorkoutDays");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutSessionsId",
                table: "WorkoutDays",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutSessionsId",
                table: "WorkoutDays");

            migrationBuilder.AddColumn<Guid[]>(
                name: "WorkoutSessionsIds",
                table: "WorkoutDays",
                type: "uuid[]",
                nullable: false,
                defaultValue: new Guid[0]);
        }
    }
}
