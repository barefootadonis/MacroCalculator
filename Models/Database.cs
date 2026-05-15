using System;
using System.Collections.Generic;

namespace MacroCalculator.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; } // unique
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public decimal Height { get; set; }
        public decimal CurrentWeight { get; set; }
        public decimal GoalWeight { get; set; }
        public string ActivityLevel { get; set; }

        public int DailyCalorieGoal { get; set; }

        public decimal TargetProtein { get; set; }
        public decimal TargetCarbs { get; set; }
        public decimal TargetFat { get; set; }
        public decimal TargetFiber { get; set; }

        public string? ProfilePicturePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Role { get; set; } = "User";
        public string AccountStatus { get; set; }

        public ICollection<SavedMeal> SavedMeals { get; set; }
        public ICollection<DailyLog> DailyLogs { get; set; }
        public ICollection<FoodEntry> FoodEntries { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<WeightProgress> WeightProgressEntries { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }

    public class SavedMeal
    {
        public int SavedMealId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string MealName { get; set; }
        public string? Description { get; set; }
        public string ServingSize { get; set; }

        public int TotalCalories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
        public decimal Fiber { get; set; }

        public string? MealCategory { get; set; }
        public bool IsFavourite { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<MealIngredient> MealIngredients { get; set; }
        public ICollection<FoodEntry> FoodEntries { get; set; }

        public bool IsDeleted { get; set; } = false;
    }

    public class Ingredient
    {
        public int IngredientId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string IngredientName { get; set; }

        public string MeasurementType { get; set; } = "Grams"; // Grams or Unit
        public string? UnitName { get; set; } // e.g. large egg, slice, cup

        public int CaloriesPer100g { get; set; }
        public decimal ProteinPer100g { get; set; }
        public decimal CarbsPer100g { get; set; }
        public decimal FatPer100g { get; set; }
        public decimal FiberPer100g { get; set; }

        public decimal DefaultServingSize { get; set; }
        public string? Category { get; set; }

        public ICollection<MealIngredient> MealIngredients { get; set; }
    }

    public class MealIngredient
    {
        public int MealIngredientId { get; set; }

        public int SavedMealId { get; set; }
        public SavedMeal SavedMeal { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public decimal QuantityInGrams { get; set; }
    }

    public class DailyLog
    {
        public int DailyLogId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime LogDate { get; set; }

        public int TotalCaloriesConsumed { get; set; }
        public decimal TotalProteinConsumed { get; set; }
        public decimal TotalCarbsConsumed { get; set; }
        public decimal TotalFatConsumed { get; set; }
        public decimal TotalFiberConsumed { get; set; }

        public int CaloriesRemaining { get; set; }
        public decimal ProteinRemaining { get; set; }
        public decimal CarbsRemaining { get; set; }
        public decimal FatRemaining { get; set; }
        public decimal FiberRemaining { get; set; }

        public ICollection<FoodEntry> FoodEntries { get; set; }
    }

    public class FoodEntry
    {
        public int FoodEntryId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int DailyLogId { get; set; }
        public DailyLog DailyLog { get; set; }

        public int? SavedMealId { get; set; }
        public SavedMeal? SavedMeal { get; set; }

        public string? CustomMealName { get; set; }
        public string? MealType { get; set; } // Breakfast, Lunch, Dinner, Snack

        public int Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
        public decimal Fiber { get; set; }

        public decimal Quantity { get; set; }
        public DateTime TimeEaten { get; set; }
        public string? Notes { get; set; }
    }

    public class WeightProgress
    {
        public int WeightProgressId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public decimal Weight { get; set; }
        public DateTime DateRecorded { get; set; }
        public string? Notes { get; set; }
    }

    public class Notification
    {
        public int NotificationId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }

        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}