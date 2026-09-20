using MoWell.Models;

namespace MoWell.DTO
{
    public class HealthLogDto
    {
        public int Id { get; set; }
        public DateTime DateTime {  get; set; }
        public LogType Type { get; set; }
        public int Value { get; set; }
    }
}
