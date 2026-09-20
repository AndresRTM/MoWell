using MoWell.Models;

namespace MoWell.DTO
{
    public class HealthLogRequestDto
    {
        public DateTime DateTime { get; set; }
        public LogType Type { get; set; }
        public int Value { get; set; }
    }
}
