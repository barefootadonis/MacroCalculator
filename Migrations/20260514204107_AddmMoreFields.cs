using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCalculator.Migrations
{
    /// <inheritdoc />
    public partial class AddmMoreFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MeasurementType",
                table: "Ingredients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "Ingredients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MealType",
                table: "FoodEntries",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 1,
                column: "MealType",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 2,
                column: "MealType",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 3,
                column: "MealType",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 4,
                column: "MealType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                columns: new[] { "MeasurementType", "UnitName" },
                values: new object[] { "Grams", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                columns: new[] { "MeasurementType", "UnitName" },
                values: new object[] { "Grams", null });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                columns: new[] { "MeasurementType", "UnitName" },
                values: new object[] { "Grams", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOc2E/C0AC69L165hupiYUmG6xX4N6fpVtt41NaIyU8TTGctlVjxob2bhv9260HjiQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementType",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MealType",
                table: "FoodEntries");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENY+4ZYlEndOtcYZD2ZPXV0j2tpMIo44zBI2SWzxo8CTcImGChb84WqVkv+RiBQurg==");
        }
    }
}
