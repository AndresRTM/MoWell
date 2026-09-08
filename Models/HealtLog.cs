
namespace MoWell.Models
{
    public class HealtLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public DateTime DateTime { get; set; }

        public LogType Type { get; set; }

        public int value { get; set; }

    }
}

