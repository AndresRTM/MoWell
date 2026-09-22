
namespace MoWell.Models
{
    public class HealthLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public DateTime DateTime { get; set; }

        public LogType Type { get; set; }

        public int RatingScore { get; set; }

    }
}

