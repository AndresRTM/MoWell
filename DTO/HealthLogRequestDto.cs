using MoWell.Models;

namespace MoWell.DTO
{
    public class CreateHealthLogDto
    {
        public DateTime DateTime { get; set; }
        public LogType Type { get; set; }
        public int Value { get; set; }
    }
}
