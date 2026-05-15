namespace MacroCalculator.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

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
    }
}