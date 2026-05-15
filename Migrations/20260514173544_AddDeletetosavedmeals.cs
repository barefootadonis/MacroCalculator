using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCalculator.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletetosavedmeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SavedMeals",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 3,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SavedMeals");
        }
    }
}
