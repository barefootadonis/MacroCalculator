using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MacroCalculator.Migrations
{
    /// <inheritdoc />
    public partial class DummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "CaloriesPer100g", "CarbsPer100g", "Category", "DefaultServingSize", "FatPer100g", "FiberPer100g", "IngredientName", "ProteinPer100g" },
                values: new object[,]
                {
                    { 1, 130, 28m, "Grain", 100m, 0.3m, 0.4m, "White Rice", 2.5m },
                    { 2, 116, 21m, "Protein", 100m, 0.5m, 6m, "Black Eyed Beans", 8m },
                    { 3, 165, 0m, "Protein", 100m, 3.6m, 0m, "Chicken Breast", 31m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AccountStatus", "ActivityLevel", "CreatedDate", "CurrentWeight", "DailyCalorieGoal", "DateOfBirth", "Email", "FirstName", "Gender", "GoalWeight", "Height", "LastLogin", "LastName", "PasswordHash", "PhoneNumber", "ProfilePicturePath", "TargetCarbs", "TargetFat", "TargetFiber", "TargetProtein" },
                values: new object[,]
                {
                    { 1, "Active", "Moderate", new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3607), 78m, 1650, new DateTime(2003, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "Alice", "Female", 65m, 167m, null, "Johnson", "hashedpassword1", "07111111111", null, 180m, 55m, 25m, 120m },
                    { 2, "Active", "High", new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3655), 90m, 2400, new DateTime(1999, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel@example.com", "Daniel", "Male", 82m, 182m, null, "Smith", "hashedpassword2", "07222222222", null, 250m, 70m, 30m, 170m },
                    { 3, "Active", "Low", new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3662), 60m, 1500, new DateTime(2001, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "maya@example.com", "Maya", "Female", 58m, 160m, null, "Brown", "hashedpassword3", "07333333333", null, 150m, 45m, 22m, 100m }
                });

            migrationBuilder.InsertData(
                table: "DailyLogs",
                columns: new[] { "DailyLogId", "CaloriesRemaining", "CarbsRemaining", "FatRemaining", "FiberRemaining", "LogDate", "ProteinRemaining", "TotalCaloriesConsumed", "TotalCarbsConsumed", "TotalFatConsumed", "TotalFiberConsumed", "TotalProteinConsumed", "UserId" },
                values: new object[,]
                {
                    { 1, 550, 60m, 23m, 11m, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 45m, 1100, 120m, 32m, 14m, 75m, 1 },
                    { 2, 600, 70m, 25m, 12m, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 40m, 1800, 180m, 45m, 18m, 130m, 2 },
                    { 3, 600, 55m, 21m, 12m, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 45m, 900, 95m, 24m, 10m, 55m, 3 }
                });

            migrationBuilder.InsertData(
                table: "SavedMeals",
                columns: new[] { "SavedMealId", "Carbs", "CreatedDate", "Description", "Fat", "Fiber", "IsFavourite", "MealCategory", "MealName", "Protein", "ServingSize", "TotalCalories", "UserId" },
                values: new object[,]
                {
                    { 1, 74m, new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3849), "Nigerian rice and black eyed beans", 12m, 8m, true, "Lunch", "Rice and Beans", 18m, "1 Bowl", 520, 1 },
                    { 2, 28m, new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3855), "Banana protein smoothie", 9m, 5m, true, "Breakfast", "Protein Smoothie", 32m, "1 Glass", 340, 1 },
                    { 3, 40m, new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3860), "Chicken tortilla wrap", 14m, 4m, false, "Dinner", "Chicken Wrap", 35m, "1 Wrap", 430, 2 }
                });

            migrationBuilder.InsertData(
                table: "WeightProgressEntries",
                columns: new[] { "WeightProgressId", "DateRecorded", "Notes", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Local), "Starting point", 1, 78m },
                    { 2, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), "Progress update", 1, 76.5m },
                    { 3, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), "Current weight", 1, 75.8m }
                });

            migrationBuilder.InsertData(
                table: "FoodEntries",
                columns: new[] { "FoodEntryId", "Calories", "Carbs", "CustomMealName", "DailyLogId", "Fat", "Fiber", "Notes", "Protein", "Quantity", "SavedMealId", "TimeEaten" },
                values: new object[,]
                {
                    { 1, 520, 74m, null, 1, 12m, 8m, "Lunch meal", 18m, 1m, 1, new DateTime(2026, 5, 14, 13, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 340, 28m, null, 1, 9m, 5m, "Breakfast smoothie", 32m, 1m, 2, new DateTime(2026, 5, 14, 9, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 220, 18m, "Protein Bar", 2, 7m, 3m, "Post workout snack", 20m, 1m, null, new DateTime(2026, 5, 14, 16, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "MealIngredients",
                columns: new[] { "MealIngredientId", "IngredientId", "QuantityInGrams", "SavedMealId" },
                values: new object[,]
                {
                    { 1, 1, 200m, 1 },
                    { 2, 2, 150m, 1 },
                    { 3, 3, 180m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MealIngredients",
                keyColumn: "MealIngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MealIngredients",
                keyColumn: "MealIngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MealIngredients",
                keyColumn: "MealIngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WeightProgressEntries",
                keyColumn: "WeightProgressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WeightProgressEntries",
                keyColumn: "WeightProgressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WeightProgressEntries",
                keyColumn: "WeightProgressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
