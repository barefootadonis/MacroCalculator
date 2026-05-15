using MacroCalculator.Models;

namespace MacroCalculator.ViewModels
{
    public class DashboardViewModel
    {
        public User User { get; set; }
        public DailyLog? TodayLog { get; set; }
        public List<DailyLog> PastLogs { get; set; } = new List<DailyLog>();
    }
}