using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroCalculator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IngredientName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CaloriesPer100g = table.Column<int>(type: "int", nullable: false),
                    ProteinPer100g = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CarbsPer100g = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FatPer100g = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FiberPer100g = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DefaultServingSize = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Height = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CurrentWeight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GoalWeight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ActivityLevel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DailyCalorieGoal = table.Column<int>(type: "int", nullable: false),
                    TargetProtein = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TargetCarbs = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TargetFat = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TargetFiber = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ProfilePicturePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AccountStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DailyLogs",
                columns: table => new
                {
                    DailyLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TotalCaloriesConsumed = table.Column<int>(type: "int", nullable: false),
                    TotalProteinConsumed = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalCarbsConsumed = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalFatConsumed = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalFiberConsumed = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CaloriesRemaining = table.Column<int>(type: "int", nullable: false),
                    ProteinRemaining = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CarbsRemaining = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FatRemaining = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    FiberRemaining = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyLogs", x => x.DailyLogId);
                    table.ForeignKey(
                        name: "FK_DailyLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SavedMeals",
                columns: table => new
                {
                    SavedMealId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MealName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServingSize = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalCalories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fiber = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MealCategory = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsFavourite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedMeals", x => x.SavedMealId);
                    table.ForeignKey(
                        name: "FK_SavedMeals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeightProgressEntries",
                columns: table => new
                {
                    WeightProgressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DateRecorded = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightProgressEntries", x => x.WeightProgressId);
                    table.ForeignKey(
                        name: "FK_WeightProgressEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FoodEntries",
                columns: table => new
                {
                    FoodEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DailyLogId = table.Column<int>(type: "int", nullable: false),
                    SavedMealId = table.Column<int>(type: "int", nullable: true),
                    CustomMealName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fiber = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TimeEaten = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEntries", x => x.FoodEntryId);
                    table.ForeignKey(
                        name: "FK_FoodEntries_DailyLogs_DailyLogId",
                        column: x => x.DailyLogId,
                        principalTable: "DailyLogs",
                        principalColumn: "DailyLogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodEntries_SavedMeals_SavedMealId",
                        column: x => x.SavedMealId,
                        principalTable: "SavedMeals",
                        principalColumn: "SavedMealId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MealIngredients",
                columns: table => new
                {
                    MealIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SavedMealId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    QuantityInGrams = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealIngredients", x => x.MealIngredientId);
                    table.ForeignKey(
                        name: "FK_MealIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealIngredients_SavedMeals_SavedMealId",
                        column: x => x.SavedMealId,
                        principalTable: "SavedMeals",
                        principalColumn: "SavedMealId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DailyLogs_UserId",
                table: "DailyLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntries_DailyLogId",
                table: "FoodEntries",
                column: "DailyLogId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodEntries_SavedMealId",
                table: "FoodEntries",
                column: "SavedMealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_SavedMealId",
                table: "MealIngredients",
                column: "SavedMealId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedMeals_UserId",
                table: "SavedMeals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightProgressEntries_UserId",
                table: "WeightProgressEntries",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodEntries");

            migrationBuilder.DropTable(
                name: "MealIngredients");

            migrationBuilder.DropTable(
                name: "WeightProgressEntries");

            migrationBuilder.DropTable(
                name: "DailyLogs");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "SavedMeals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
