using MacroCalculator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MacroCalculator.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var passwordHasher = new PasswordHasher<User>();
            var seedDate = new DateTime(2026, 5, 14);

            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            var adminUser = new User
            {
                UserId = 5,
                Username = "admin",
                FirstName = "System",
                LastName = "Administrator",
                Email = "admin@macrotrack.com",
                PhoneNumber = "07000000000",
                PasswordHash = passwordHasher.HashPassword(null, "Admin123!"),
                DateOfBirth = new DateTime(1995, 1, 1),
                Gender = "Other",
                Height = 170,
                CurrentWeight = 70,
                GoalWeight = 70,
                ActivityLevel = "Moderate",
                DailyCalorieGoal = 2000,
                TargetProtein = 120,
                TargetCarbs = 220,
                TargetFat = 65,
                TargetFiber = 30,
                CreatedDate = seedDate,
                LastLogin = null,
                AccountStatus = "Active",
                Role = "Admin"
            };

            builder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "alice",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice@example.com",
                    PhoneNumber = "07111111111",
                    PasswordHash = "password1",
                    DateOfBirth = new DateTime(2003, 5, 12),
                    Gender = "Female",
                    Height = 167,
                    CurrentWeight = 78,
                    GoalWeight = 65,
                    ActivityLevel = "Moderate",
                    DailyCalorieGoal = 1650,
                    TargetProtein = 120,
                    TargetCarbs = 180,
                    TargetFat = 55,
                    TargetFiber = 25,
                    CreatedDate = seedDate,
                    LastLogin = seedDate,
                    AccountStatus = "Active"
                },
                new User
                {
                    UserId = 2,
                    Username = "daniel",
                    FirstName = "Daniel",
                    LastName = "Smith",
                    Email = "daniel@example.com",
                    PhoneNumber = "07222222222",
                    PasswordHash = "password2",
                    DateOfBirth = new DateTime(1999, 9, 21),
                    Gender = "Male",
                    Height = 182,
                    CurrentWeight = 90,
                    GoalWeight = 82,
                    ActivityLevel = "High",
                    DailyCalorieGoal = 2400,
                    TargetProtein = 170,
                    TargetCarbs = 250,
                    TargetFat = 70,
                    TargetFiber = 30,
                    CreatedDate = seedDate,
                    LastLogin = seedDate,
                    AccountStatus = "Active"
                },
                new User
                {
                    UserId = 3,
                    Username = "maya",
                    FirstName = "Maya",
                    LastName = "Brown",
                    Email = "maya@example.com",
                    PhoneNumber = "07333333333",
                    PasswordHash = "password3",
                    DateOfBirth = new DateTime(2001, 1, 7),
                    Gender = "Female",
                    Height = 160,
                    CurrentWeight = 60,
                    GoalWeight = 58,
                    ActivityLevel = "Low",
                    DailyCalorieGoal = 1500,
                    TargetProtein = 100,
                    TargetCarbs = 150,
                    TargetFat = 45,
                    TargetFiber = 22,
                    CreatedDate = seedDate,
                    LastLogin = seedDate,
                    AccountStatus = "Active"
                },
                adminUser
            );

            builder.Entity<SavedMeal>().HasData(
                new SavedMeal
                {
                    SavedMealId = 1,
                    UserId = 1,
                    MealName = "Rice and Beans",
                    Description = "Nigerian rice and black eyed beans",
                    ServingSize = "1 Bowl",
                    TotalCalories = 520,
                    Protein = 18,
                    Carbs = 74,
                    Fat = 12,
                    Fiber = 8,
                    MealCategory = "Lunch",
                    IsFavourite = true,
                    CreatedDate = seedDate
                },
                new SavedMeal
                {
                    SavedMealId = 2,
                    UserId = 1,
                    MealName = "Protein Smoothie",
                    Description = "Banana protein smoothie",
                    ServingSize = "1 Glass",
                    TotalCalories = 340,
                    Protein = 32,
                    Carbs = 28,
                    Fat = 9,
                    Fiber = 5,
                    MealCategory = "Breakfast",
                    IsFavourite = true,
                    CreatedDate = seedDate
                },
                new SavedMeal
                {
                    SavedMealId = 3,
                    UserId = 2,
                    MealName = "Chicken Wrap",
                    Description = "Chicken tortilla wrap",
                    ServingSize = "1 Wrap",
                    TotalCalories = 430,
                    Protein = 35,
                    Carbs = 40,
                    Fat = 14,
                    Fiber = 4,
                    MealCategory = "Dinner",
                    IsFavourite = false,
                    CreatedDate = seedDate
                }
            );

            builder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    IngredientId = 1,
                    UserId = 1,
                    IngredientName = "White Rice",
                    CaloriesPer100g = 130,
                    ProteinPer100g = 2.5m,
                    CarbsPer100g = 28,
                    FatPer100g = 0.3m,
                    FiberPer100g = 0.4m,
                    DefaultServingSize = 100,
                    Category = "Grain"
                },
                new Ingredient
                {
                    IngredientId = 2,
                    UserId = 1,
                    IngredientName = "Black Eyed Beans",
                    CaloriesPer100g = 116,
                    ProteinPer100g = 8,
                    CarbsPer100g = 21,
                    FatPer100g = 0.5m,
                    FiberPer100g = 6,
                    DefaultServingSize = 100,
                    Category = "Protein"
                },
                new Ingredient
                {
                    IngredientId = 3,
                    UserId = 2,
                    IngredientName = "Chicken Breast",
                    CaloriesPer100g = 165,
                    ProteinPer100g = 31,
                    CarbsPer100g = 0,
                    FatPer100g = 3.6m,
                    FiberPer100g = 0,
                    DefaultServingSize = 100,
                    Category = "Protein"
                }
            );

            builder.Entity<MealIngredient>().HasData(
                new MealIngredient
                {
                    MealIngredientId = 1,
                    SavedMealId = 1,
                    IngredientId = 1,
                    QuantityInGrams = 200
                },
                new MealIngredient
                {
                    MealIngredientId = 2,
                    SavedMealId = 1,
                    IngredientId = 2,
                    QuantityInGrams = 150
                },
                new MealIngredient
                {
                    MealIngredientId = 3,
                    SavedMealId = 3,
                    IngredientId = 3,
                    QuantityInGrams = 180
                }
            );

            builder.Entity<DailyLog>().HasData(
                new DailyLog
                {
                    DailyLogId = 1,
                    UserId = 1,
                    LogDate = seedDate,
                    TotalCaloriesConsumed = 1100,
                    TotalProteinConsumed = 75,
                    TotalCarbsConsumed = 120,
                    TotalFatConsumed = 32,
                    TotalFiberConsumed = 14,
                    CaloriesRemaining = 550,
                    ProteinRemaining = 45,
                    CarbsRemaining = 60,
                    FatRemaining = 23,
                    FiberRemaining = 11
                },
                new DailyLog
                {
                    DailyLogId = 2,
                    UserId = 1,
                    LogDate = seedDate.AddDays(-1),
                    TotalCaloriesConsumed = 1480,
                    TotalProteinConsumed = 95,
                    TotalCarbsConsumed = 160,
                    TotalFatConsumed = 46,
                    TotalFiberConsumed = 21,
                    CaloriesRemaining = 170,
                    ProteinRemaining = 25,
                    CarbsRemaining = 20,
                    FatRemaining = 9,
                    FiberRemaining = 4
                },
                new DailyLog
                {
                    DailyLogId = 3,
                    UserId = 1,
                    LogDate = seedDate.AddDays(-2),
                    TotalCaloriesConsumed = 1610,
                    TotalProteinConsumed = 102,
                    TotalCarbsConsumed = 174,
                    TotalFatConsumed = 50,
                    TotalFiberConsumed = 23,
                    CaloriesRemaining = 40,
                    ProteinRemaining = 18,
                    CarbsRemaining = 6,
                    FatRemaining = 5,
                    FiberRemaining = 2
                }
            );

            builder.Entity<FoodEntry>().HasData(
                new FoodEntry
                {
                    FoodEntryId = 1,
                    UserId = 1,
                    DailyLogId = 1,
                    SavedMealId = 1,
                    Calories = 520,
                    Protein = 18,
                    Carbs = 74,
                    Fat = 12,
                    Fiber = 8,
                    Quantity = 1,
                    TimeEaten = seedDate.AddHours(13),
                    Notes = "Lunch meal"
                },
                new FoodEntry
                {
                    FoodEntryId = 2,
                    UserId = 1,
                    DailyLogId = 1,
                    SavedMealId = 2,
                    Calories = 340,
                    Protein = 32,
                    Carbs = 28,
                    Fat = 9,
                    Fiber = 5,
                    Quantity = 1,
                    TimeEaten = seedDate.AddHours(9),
                    Notes = "Breakfast smoothie"
                },
                new FoodEntry
                {
                    FoodEntryId = 3,
                    UserId = 1,
                    DailyLogId = 2,
                    CustomMealName = "Chicken Wrap",
                    Calories = 410,
                    Protein = 35,
                    Carbs = 40,
                    Fat = 14,
                    Fiber = 4,
                    Quantity = 1,
                    TimeEaten = seedDate.AddDays(-1).AddHours(14),
                    Notes = "Yesterday lunch"
                },
                new FoodEntry
                {
                    FoodEntryId = 4,
                    UserId = 1,
                    DailyLogId = 3,
                    CustomMealName = "Eba and Egusi",
                    Calories = 680,
                    Protein = 28,
                    Carbs = 82,
                    Fat = 24,
                    Fiber = 10,
                    Quantity = 1,
                    TimeEaten = seedDate.AddDays(-2).AddHours(18),
                    Notes = "Dinner"
                }
            );

            builder.Entity<WeightProgress>().HasData(
                new WeightProgress
                {
                    WeightProgressId = 1,
                    UserId = 1,
                    Weight = 78,
                    DateRecorded = seedDate.AddDays(-14),
                    Notes = "Starting point"
                },
                new WeightProgress
                {
                    WeightProgressId = 2,
                    UserId = 1,
                    Weight = 76.5m,
                    DateRecorded = seedDate.AddDays(-7),
                    Notes = "Progress update"
                },
                new WeightProgress
                {
                    WeightProgressId = 3,
                    UserId = 1,
                    Weight = 75.8m,
                    DateRecorded = seedDate,
                    Notes = "Current weight"
                }
            );
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SavedMeal> SavedMeals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }
        public DbSet<DailyLog> DailyLogs { get; set; }
        public DbSet<FoodEntry> FoodEntries { get; set; }
        public DbSet<WeightProgress> WeightProgressEntries { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}