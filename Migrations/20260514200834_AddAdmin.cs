using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCalculator.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Role",
                value: "User");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Role",
                value: "User");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Role",
                value: "User");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AccountStatus", "ActivityLevel", "CreatedDate", "CurrentWeight", "DailyCalorieGoal", "DateOfBirth", "Email", "FirstName", "Gender", "GoalWeight", "Height", "LastLogin", "LastName", "PasswordHash", "PhoneNumber", "ProfilePicturePath", "Role", "TargetCarbs", "TargetFat", "TargetFiber", "TargetProtein", "Username" },
                values: new object[] { 5, "Active", "Moderate", new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 70m, 2000, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@macrotrack.com", "System", "Other", 70m, 170m, null, "Administrator", "AQAAAAIAAYagAAAAENY+4ZYlEndOtcYZD2ZPXV0j2tpMIo44zBI2SWzxo8CTcImGChb84WqVkv+RiBQurg==", "07000000000", null, "Admin", 220m, 65m, 30m, 120m, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
