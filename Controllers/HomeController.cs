using MacroCalculator.Data;
using MacroCalculator.Models;
using MacroCalculator.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MacroCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void PreventPageCaching()
        {
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
        }

        public async Task<IActionResult> Index(DateTime? date)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }


            DateTime selectedDate = date?.Date ?? DateTime.Today;

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            await CheckDailyGoalNotifications(userId.Value);

            ViewBag.UnreadNotificationCount = await _context.Notifications
                .CountAsync(n => n.UserId == userId.Value && !n.IsRead);

            var todayLog = await _context.DailyLogs
                .Include(d => d.FoodEntries)
                    .ThenInclude(f => f.SavedMeal)
                .FirstOrDefaultAsync(d =>
                    d.UserId == userId.Value &&
                    d.LogDate.Date == selectedDate.Date);

            var pastLogs = await _context.DailyLogs
                .Include(d => d.FoodEntries)
                    .ThenInclude(f => f.SavedMeal)
                .Where(d =>
                    d.UserId == userId.Value &&
                    d.LogDate.Date < selectedDate.Date)
                .OrderByDescending(d => d.LogDate)
                .Take(2)
                .ToListAsync();

            var viewModel = new DashboardViewModel
            {
                User = user,
                TodayLog = todayLog,
                PastLogs = pastLogs
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Progress()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var weightProgress = await _context.WeightProgressEntries
                .Where(w => w.UserId == userId.Value)
                .OrderByDescending(w => w.DateRecorded)
                .Take(5)
                .OrderBy(w => w.DateRecorded)
                .ToListAsync();

            var dailyLogs = await _context.DailyLogs
                .Include(d => d.FoodEntries)
                .Where(d => d.UserId == userId.Value)
                .OrderByDescending(d => d.LogDate)
                .Take(5)
                .OrderBy(d => d.LogDate)
                .ToListAsync();

            var viewModel = new ProgressViewModel
            {
                User = user,
                WeightProgress = weightProgress,
                DailyLogs = dailyLogs
            };

            return View(viewModel);
        }

        public async Task<IActionResult> DailyLogs(DateTime? searchDate)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var today = DateTime.Today;

            var logsQuery = _context.DailyLogs
                .Include(d => d.FoodEntries)
                    .ThenInclude(f => f.SavedMeal)
                .Where(d =>
                    d.UserId == userId.Value &&
                    d.LogDate.Date < today);

            if (searchDate.HasValue)
            {
                logsQuery = logsQuery.Where(d => d.LogDate.Date == searchDate.Value.Date);
            }

            var logs = await logsQuery
                .OrderBy(d => d.LogDate)
                .ToListAsync();

            ViewBag.SearchDate = searchDate?.ToString("yyyy-MM-dd");

            return View(logs);
        }

        public async Task<IActionResult> SavedMeals()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var meals = await _context.SavedMeals
                .Where(m => m.UserId == userId.Value && !m.IsDeleted)
                .OrderBy(m => m.MealName)
                .ToListAsync();

            return View(meals);
        }

        [HttpGet]
        public IActionResult CreateMeal()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeal(SavedMeal meal)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            meal.UserId = userId.Value;
            meal.CreatedDate = DateTime.Now;

            _context.SavedMeals.Add(meal);
            await _context.SaveChangesAsync();

            return RedirectToAction("SavedMeals");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var meal = await _context.SavedMeals
                .FirstOrDefaultAsync(m => m.SavedMealId == id && m.UserId == userId.Value);

            if (meal == null)
                return NotFound();

            meal.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("SavedMeals");
        }

        [HttpGet]
        public async Task<IActionResult> EditMeal(int id)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var meal = await _context.SavedMeals
                .FirstOrDefaultAsync(m => m.SavedMealId == id && m.UserId == userId.Value && !m.IsDeleted);

            if (meal == null)
                return NotFound();

            return View(meal);
        }

        [HttpPost]
        public async Task<IActionResult> EditMeal(SavedMeal updatedMeal)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var meal = await _context.SavedMeals
                .FirstOrDefaultAsync(m => m.SavedMealId == updatedMeal.SavedMealId && m.UserId == userId.Value && !m.IsDeleted);

            if (meal == null)
                return NotFound();

            meal.MealName = updatedMeal.MealName;
            meal.Description = updatedMeal.Description;
            meal.ServingSize = updatedMeal.ServingSize;
            meal.TotalCalories = updatedMeal.TotalCalories;
            meal.Protein = updatedMeal.Protein;
            meal.Carbs = updatedMeal.Carbs;
            meal.Fat = updatedMeal.Fat;
            meal.Fiber = updatedMeal.Fiber;
            meal.MealCategory = updatedMeal.MealCategory;
            meal.IsFavourite = updatedMeal.IsFavourite;

            await _context.SaveChangesAsync();

            return RedirectToAction("SavedMeals");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(User updatedUser)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            decimal oldWeight = user.CurrentWeight;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.DateOfBirth = updatedUser.DateOfBirth;
            user.Gender = updatedUser.Gender;
            user.Height = updatedUser.Height;
            user.CurrentWeight = updatedUser.CurrentWeight;
            user.GoalWeight = updatedUser.GoalWeight;
            user.ActivityLevel = updatedUser.ActivityLevel;

            if (oldWeight != updatedUser.CurrentWeight)
            {
                _context.WeightProgressEntries.Add(new WeightProgress
                {
                    UserId = user.UserId,
                    Weight = updatedUser.CurrentWeight,
                    DateRecorded = DateTime.Now,
                    Notes = "Weight updated from profile"
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(User updatedUser)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            user.DailyCalorieGoal = updatedUser.DailyCalorieGoal;
            user.TargetProtein = updatedUser.TargetProtein;
            user.TargetCarbs = updatedUser.TargetCarbs;
            user.TargetFat = updatedUser.TargetFat;
            user.TargetFiber = updatedUser.TargetFiber;

            await _context.SaveChangesAsync();

            return RedirectToAction("Settings");
        }

        public async Task<IActionResult> Notifications()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId.Value)
                .OrderByDescending(n => n.CreatedDate)
                .ToListAsync();

            return View(notifications);
        }

        [HttpPost]
        public async Task<IActionResult> MarkNotificationRead(int id)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var notification = await _context.Notifications
                .FirstOrDefaultAsync(n => n.NotificationId == id && n.UserId == userId.Value);

            if (notification == null)
                return NotFound();

            notification.IsRead = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Notifications");
        }

        private async Task CreateNotificationIfMissing(int userId, string title, string message, string type)
        {
            bool exists = await _context.Notifications.AnyAsync(n =>
                n.UserId == userId &&
                n.Title == title &&
                n.Message == message &&
                n.CreatedDate.Date == DateTime.Today);

            if (!exists)
            {
                _context.Notifications.Add(new Notification
                {
                    UserId = userId,
                    Title = title,
                    Message = message,
                    NotificationType = type,
                    IsRead = false,
                    CreatedDate = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDailyGoalNotifications(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
                return;

            var todayLog = await _context.DailyLogs
                .Include(d => d.FoodEntries)
                .FirstOrDefaultAsync(d => d.UserId == userId && d.LogDate.Date == DateTime.Today);

            var latestWeight = await _context.WeightProgressEntries
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.DateRecorded)
                .FirstOrDefaultAsync();

            if (latestWeight == null)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "No weight logged yet",
                    "You have not logged your weight yet. Add your first weight entry to track your progress.",
                    "Reminder");
            }
            else
            {
                if (latestWeight.Weight <= user.GoalWeight)
                {
                    await CreateNotificationIfMissing(
                        userId,
                        "Goal weight reached",
                        "Congratulations, you have reached your goal weight.",
                        "Success");
                }

                if (latestWeight.DateRecorded.Date <= DateTime.Today.AddDays(-7))
                {
                    await CreateNotificationIfMissing(
                        userId,
                        "Weight update reminder",
                        "You have not logged a new weight in 7 days. Add a new entry to keep your progress accurate.",
                        "Reminder");
                }
            }
            


            var logCount = await _context.DailyLogs.CountAsync(d => d.UserId == userId);

            if (logCount == 10)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "10 days tracked",
                    "You have logged meals for 10 days. Please leave feedback for us.",
                    "Milestone");
            }

            if (todayLog == null)
                return;

            int calories = todayLog.FoodEntries.Sum(f => f.Calories);
            decimal protein = todayLog.FoodEntries.Sum(f => f.Protein);
            decimal carbs = todayLog.FoodEntries.Sum(f => f.Carbs);
            decimal fat = todayLog.FoodEntries.Sum(f => f.Fat);
            decimal fiber = todayLog.FoodEntries.Sum(f => f.Fiber);

            if (calories >= user.DailyCalorieGoal && calories <= user.DailyCalorieGoal + 100)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "Calorie goal reached",
                    "You reached your calorie goal for today. Nice work.",
                    "Success");
            }

            if (calories > user.DailyCalorieGoal + 100)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "Calories are over target",
                    $"You are more than 100 kcal over your daily target. Current total: {calories} kcal.",
                    "Warning");
            }

            if (protein > user.TargetProtein + 10)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "Protein is over target",
                    $"You are more than 10g over your protein target. Current total: {protein.ToString("0.00")}g.",
                    "Warning");
            }

            if (carbs > user.TargetCarbs + 10)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "Carbs are over target",
                    $"You are more than 10g over your carbs target. Current total: {carbs.ToString("0.00")}g.",
                    "Warning");
            }

            if (fat > user.TargetFat + 10)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "Fat is over target",
                    $"You are more than 10g over your fat target. Current total: {fat.ToString("0.00")}g.",
                    "Warning");
            }

            if (fiber >= user.TargetFiber)
            {
                await CreateNotificationIfMissing(
                    userId,
                    "Fiber goal reached",
                    "You reached your fiber goal for today.",
                    "Success");
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            if (model.NewPassword != model.ConfirmPassword)
            {
                ViewBag.Error = "New passwords do not match.";
                return View(model);
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                model.CurrentPassword
            );

            if (result == PasswordVerificationResult.Failed)
            {
                ViewBag.Error = "Current password is incorrect.";
                return View(model);
            }

            user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);

            await _context.SaveChangesAsync();

            ViewBag.Success = "Password changed successfully.";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddFood()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var viewModel = new AddFoodViewModel
            {
                SavedMeals = await _context.SavedMeals
                    .Where(m => m.UserId == userId.Value && !m.IsDeleted)
                    .OrderBy(m => m.MealName)
                    .ToListAsync(),

                Ingredients = await _context.Ingredients
                    .Where(i => i.UserId == userId.Value)
                    .OrderBy(i => i.IngredientName)
                    .ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFood(AddFoodViewModel model)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            DateTime today = DateTime.Today;

            var dailyLog = await _context.DailyLogs
                .FirstOrDefaultAsync(d => d.UserId == userId.Value && d.LogDate.Date == today);

            if (dailyLog == null)
            {
                dailyLog = new DailyLog
                {
                    UserId = userId.Value,
                    LogDate = today
                };

                _context.DailyLogs.Add(dailyLog);
                await _context.SaveChangesAsync();
            }

            if (model.LogType == "SavedMeal" && model.SavedMealId.HasValue)
            {
                var meal = await _context.SavedMeals
                    .FirstOrDefaultAsync(m => m.SavedMealId == model.SavedMealId.Value && m.UserId == userId.Value);

                if (meal == null)
                    return NotFound();

                decimal quantity = model.SavedMealQuantity <= 0 ? 1 : model.SavedMealQuantity;

                var entry = new FoodEntry
                {
                    UserId = userId.Value,
                    DailyLogId = dailyLog.DailyLogId,
                    SavedMealId = meal.SavedMealId,
                    CustomMealName = meal.MealName,
                    Quantity = quantity,
                    TimeEaten = DateTime.Now,
                    Notes = model.Notes,
                    MealType = model.MealType,
                    Calories = (int)Math.Round(meal.TotalCalories * quantity),
                    Protein = Math.Round(meal.Protein * quantity, 2),
                    Carbs = Math.Round(meal.Carbs * quantity, 2),
                    Fat = Math.Round(meal.Fat * quantity, 2),
                    Fiber = Math.Round(meal.Fiber * quantity, 2)
                };

                _context.FoodEntries.Add(entry);
            }
            else if (model.LogType == "Ingredient" && model.IngredientIds.Any())
            {
                for (int index = 0; index < model.IngredientIds.Count; index++)
                {
                    int ingredientId = model.IngredientIds[index];

                    var ingredient = await _context.Ingredients
                        .FirstOrDefaultAsync(i =>
                            i.IngredientId == ingredientId &&
                            i.UserId == userId.Value);

                    if (ingredient == null)
                        continue;

                    var entry = new FoodEntry
                    {
                        UserId = userId.Value,
                        DailyLogId = dailyLog.DailyLogId,
                        TimeEaten = DateTime.Now,
                        Notes = model.Notes,
                        MealType = model.MealType
                    };

                    if (ingredient.MeasurementType == "Unit")
                    {
                        decimal quantity = model.IngredientQuantityList.Count > index && model.IngredientQuantityList[index] > 0
                            ? model.IngredientQuantityList[index]
                            : 1;

                        entry.CustomMealName = $"{quantity} x {ingredient.IngredientName}";
                        entry.Quantity = quantity;

                        entry.Calories = (int)Math.Round(ingredient.CaloriesPer100g * quantity);
                        entry.Protein = Math.Round(ingredient.ProteinPer100g * quantity, 2);
                        entry.Carbs = Math.Round(ingredient.CarbsPer100g * quantity, 2);
                        entry.Fat = Math.Round(ingredient.FatPer100g * quantity, 2);
                        entry.Fiber = Math.Round(ingredient.FiberPer100g * quantity, 2);
                    }
                    else
                    {
                        decimal grams = model.IngredientGramsList.Count > index && model.IngredientGramsList[index] > 0
                            ? model.IngredientGramsList[index]
                            : ingredient.DefaultServingSize;

                        decimal multiplier = grams / 100;

                        entry.CustomMealName = $"{grams}g {ingredient.IngredientName}";
                        entry.Quantity = grams;

                        entry.Calories = (int)Math.Round(ingredient.CaloriesPer100g * multiplier);
                        entry.Protein = Math.Round(ingredient.ProteinPer100g * multiplier, 2);
                        entry.Carbs = Math.Round(ingredient.CarbsPer100g * multiplier, 2);
                        entry.Fat = Math.Round(ingredient.FatPer100g * multiplier, 2);
                        entry.Fiber = Math.Round(ingredient.FiberPer100g * multiplier, 2);
                    }

                    _context.FoodEntries.Add(entry);
                }
            }
            else if (model.LogType == "Custom")
            {
                var entry = new FoodEntry
                {
                    UserId = userId.Value,
                    DailyLogId = dailyLog.DailyLogId,
                    CustomMealName = model.CustomMealName,
                    Calories = model.CustomCalories,
                    Protein = model.CustomProtein,
                    Carbs = model.CustomCarbs,
                    Fat = model.CustomFat,
                    Fiber = model.CustomFiber,
                    Quantity = 1,
                    TimeEaten = DateTime.Now,
                    Notes = model.Notes,
                    MealType = model.MealType
                };

                _context.FoodEntries.Add(entry);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Ingredients()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var ingredients = await _context.Ingredients
                .Where(i => i.UserId == userId.Value)
                .OrderBy(i => i.IngredientName)
                .ToListAsync();

            return View(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(Ingredient ingredient)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            ingredient.UserId = userId.Value;

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return RedirectToAction("Ingredients");
        }

        public async Task<IActionResult> AdminUsers()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (currentUser == null || currentUser.Role != "Admin")
                return RedirectToAction("Index");

            var users = await _context.Users
                .OrderBy(u => u.Username)
                .ToListAsync();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleUserStatus(int id)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var currentUser = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId.Value);

            if (currentUser == null || currentUser.Role != "Admin")
                return RedirectToAction("Index");

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
                return NotFound();

            if (user.Role == "Admin")
                return RedirectToAction("AdminUsers");

            user.AccountStatus =
                user.AccountStatus == "Inactive"
                ? "Active"
                : "Inactive";

            await _context.SaveChangesAsync();

            return RedirectToAction("AdminUsers");
        }

        [HttpGet]
        public IActionResult CreateIngredient()
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditIngredient(int id)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(i =>
                    i.IngredientId == id &&
                    i.UserId == userId.Value);

            if (ingredient == null)
                return NotFound();

            return View(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> EditIngredient(Ingredient updatedIngredient)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(i =>
                    i.IngredientId == updatedIngredient.IngredientId &&
                    i.UserId == userId.Value);

            if (ingredient == null)
                return NotFound();

            ingredient.IngredientName = updatedIngredient.IngredientName;
            ingredient.MeasurementType = updatedIngredient.MeasurementType;
            ingredient.UnitName = updatedIngredient.UnitName;

            ingredient.CaloriesPer100g = updatedIngredient.CaloriesPer100g;
            ingredient.ProteinPer100g = updatedIngredient.ProteinPer100g;
            ingredient.CarbsPer100g = updatedIngredient.CarbsPer100g;
            ingredient.FatPer100g = updatedIngredient.FatPer100g;
            ingredient.FiberPer100g = updatedIngredient.FiberPer100g;

            ingredient.DefaultServingSize = updatedIngredient.DefaultServingSize;
            ingredient.Category = updatedIngredient.Category;

            await _context.SaveChangesAsync();

            return RedirectToAction("Ingredients");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            PreventPageCaching();

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            var ingredient = await _context.Ingredients
                .FirstOrDefaultAsync(i =>
                    i.IngredientId == id &&
                    i.UserId == userId.Value);

            if (ingredient == null)
                return NotFound();

            _context.Ingredients.Remove(ingredient);

            await _context.SaveChangesAsync();

            return RedirectToAction("Ingredients");
        }


    }
}