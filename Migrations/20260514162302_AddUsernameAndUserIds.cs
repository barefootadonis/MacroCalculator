using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCalculator.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameAndUserIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FoodEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 2,
                columns: new[] { "CaloriesRemaining", "CarbsRemaining", "FatRemaining", "FiberRemaining", "LogDate", "ProteinRemaining", "TotalCaloriesConsumed", "TotalCarbsConsumed", "TotalFatConsumed", "TotalFiberConsumed", "TotalProteinConsumed", "UserId" },
                values: new object[] { 170, 20m, 9m, 4m, new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 25m, 1480, 160m, 46m, 21m, 95m, 1 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 3,
                columns: new[] { "CaloriesRemaining", "CarbsRemaining", "FatRemaining", "FiberRemaining", "LogDate", "ProteinRemaining", "TotalCaloriesConsumed", "TotalCarbsConsumed", "TotalFatConsumed", "TotalFiberConsumed", "TotalProteinConsumed", "UserId" },
                values: new object[] { 40, 6m, 5m, 2m, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 18m, 1610, 174m, 50m, 23m, 102m, 1 });

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 3,
                columns: new[] { "Calories", "Carbs", "CustomMealName", "Fat", "Fiber", "Notes", "Protein", "TimeEaten", "UserId" },
                values: new object[] { 410, 40m, "Chicken Wrap", 14m, 4m, "Yesterday lunch", 35m, new DateTime(2026, 5, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "FoodEntries",
                columns: new[] { "FoodEntryId", "Calories", "Carbs", "CustomMealName", "DailyLogId", "Fat", "Fiber", "Notes", "Protein", "Quantity", "SavedMealId", "TimeEaten", "UserId" },
                values: new object[] { 4, 680, 82m, "Eba and Egusi", 3, 24m, 10m, "Dinner", 28m, 1m, null, new DateTime(2026, 5, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastLogin", "PasswordHash", "Username" },
                values: new object[] { new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "password1", "alice" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastLogin", "PasswordHash", "Username" },
                values: new object[] { new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "password2", "daniel" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastLogin", "PasswordHash", "Username" },
                values: new object[] { new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "password3", "maya" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_UserId",
                table: "Ingredients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntries_UserId",
                table: "FoodEntries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodEntries_Users_UserId",
                table: "FoodEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Users_UserId",
                table: "Ingredients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodEntries_Users_UserId",
                table: "FoodEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Users_UserId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_UserId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_FoodEntries_UserId",
                table: "FoodEntries");

            migrationBuilder.DeleteData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoodEntries");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 2,
                columns: new[] { "CaloriesRemaining", "CarbsRemaining", "FatRemaining", "FiberRemaining", "LogDate", "ProteinRemaining", "TotalCaloriesConsumed", "TotalCarbsConsumed", "TotalFatConsumed", "TotalFiberConsumed", "TotalProteinConsumed", "UserId" },
                values: new object[] { 600, 70m, 25m, 12m, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 40m, 1800, 180m, 45m, 18m, 130m, 2 });

            migrationBuilder.UpdateData(
                table: "DailyLogs",
                keyColumn: "DailyLogId",
                keyValue: 3,
                columns: new[] { "CaloriesRemaining", "CarbsRemaining", "FatRemaining", "FiberRemaining", "LogDate", "ProteinRemaining", "TotalCaloriesConsumed", "TotalCarbsConsumed", "TotalFatConsumed", "TotalFiberConsumed", "TotalProteinConsumed", "UserId" },
                values: new object[] { 600, 55m, 21m, 12m, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Local), 45m, 900, 95m, 24m, 10m, 55m, 3 });

            migrationBuilder.UpdateData(
                table: "FoodEntries",
                keyColumn: "FoodEntryId",
                keyValue: 3,
                columns: new[] { "Calories", "Carbs", "CustomMealName", "Fat", "Fiber", "Notes", "Protein", "TimeEaten" },
                values: new object[] { 220, 18m, "Protein Bar", 7m, 3m, "Post workout snack", 20m, new DateTime(2026, 5, 14, 16, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3855));

            migrationBuilder.UpdateData(
                table: "SavedMeals",
                keyColumn: "SavedMealId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3607), null, "hashedpassword1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3655), null, "hashedpassword2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastLogin", "PasswordHash" },
                values: new object[] { new DateTime(2026, 5, 14, 17, 5, 29, 974, DateTimeKind.Local).AddTicks(3662), null, "hashedpassword3" });
        }
    }
}
