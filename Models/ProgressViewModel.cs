using MacroCalculator.Models;

namespace MacroCalculator.ViewModels
{
    public class ProgressViewModel
    {
        public User User { get; set; }
        public List<WeightProgress> WeightProgress { get; set; } = new();
        public List<DailyLog> DailyLogs { get; set; } = new();
    }
}