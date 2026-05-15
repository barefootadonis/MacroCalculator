using MacroCalculator.Models;

namespace MacroCalculator.ViewModels
{
    public class AddFoodViewModel
    {
        public string LogType { get; set; } = "SavedMeal";
        public string? MealType { get; set; }

        public int? SavedMealId { get; set; }
        public decimal SavedMealQuantity { get; set; } = 1;

        public int? IngredientId { get; set; }
        public decimal IngredientGrams { get; set; }
        public decimal IngredientQuantity { get; set; } = 1;

        public string? CustomMealName { get; set; }
        public int CustomCalories { get; set; }
        public decimal CustomProtein { get; set; }
        public decimal CustomCarbs { get; set; }
        public decimal CustomFat { get; set; }
        public decimal CustomFiber { get; set; }

        public string? Notes { get; set; }

        public List<SavedMeal> SavedMeals { get; set; } = new();
        public List<Ingredient> Ingredients { get; set; } = new();
        public List<int> IngredientIds { get; set; } = new();
        public List<decimal> IngredientGramsList { get; set; } = new();
        public List<decimal> IngredientQuantityList { get; set; } = new();
    }
}