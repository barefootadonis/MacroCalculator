namespace MacroCalculator.ViewModels
{
    public class ForgotPasswordViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool Verified { get; set; }

        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}