using MacroCalculator.Data;
using MacroCalculator.Models;
using MacroCalculator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MacroCalculator.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u =>
                    u.Username == model.UsernameOrEmail ||
                    u.Email == model.UsernameOrEmail);

            if (user == null)
            {
                ViewBag.Error = "Invalid username/email or password.";
                return View(model);
            }

            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                model.Password
            );

            if (result == PasswordVerificationResult.Failed)
            {
                ViewBag.Error = "Invalid username/email or password.";
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("Role", user.Role);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View(model);
            }

            bool usernameExists = await _context.Users
                .AnyAsync(u => u.Username == model.Username);

            if (usernameExists)
            {
                ViewBag.Error = "This username is already taken.";
                return View(model);
            }

            bool emailExists = await _context.Users
                .AnyAsync(u => u.Email == model.Email);

            if (emailExists)
            {
                ViewBag.Error = "This email is already registered.";
                return View(model);
            }

            var user = new User
            {
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,

                PasswordHash = new PasswordHasher<User>().HashPassword(null, model.Password),

                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Height = model.Height,
                CurrentWeight = model.CurrentWeight,
                GoalWeight = model.GoalWeight,
                ActivityLevel = model.ActivityLevel,

                DailyCalorieGoal = model.DailyCalorieGoal,
                TargetProtein = model.TargetProtein,
                TargetCarbs = model.TargetCarbs,
                TargetFat = model.TargetFat,
                TargetFiber = model.TargetFiber,

                CreatedDate = DateTime.Now,
                LastLogin = DateTime.Now,
                AccountStatus = "Active",
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetInt32("UserId", user.UserId);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model, string actionType)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.Username == model.Username &&
                u.Email == model.Email &&
                u.DateOfBirth.Date == model.DateOfBirth.Date);

            if (user == null)
            {
                ViewBag.Error = "No account matched those details.";
                model.Verified = false;
                return View(model);
            }

            if (actionType == "Verify")
            {
                model.Verified = true;
                return View(model);
            }

            if (actionType == "Reset")
            {
                model.Verified = true;

                if (model.NewPassword != model.ConfirmPassword)
                {
                    ViewBag.Error = "Passwords do not match.";
                    return View(model);
                }

                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);

                await _context.SaveChangesAsync();

                ViewBag.Success = "Password reset successfully. You can now log in.";
                return View(new ForgotPasswordViewModel());
            }

            return View(model);
        }
    }
}