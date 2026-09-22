using MoWell.Models;
using System.ComponentModel.DataAnnotations;

namespace MoWell.DTO
{
    public class HealthLogRequestDto
    {
        [Required(ErrorMessage ="Tidpunkt måste anges")]
        public DateTime? DateTime { get; set; }

        [Required(ErrorMessage = "Typ måste anges")]
        [EnumDataType(typeof(LogType), ErrorMessage = "Ogiltig LogType")]
        public LogType? Type { get; set; }

        [Required(ErrorMessage = "Värdet måste anges")]
        [Range(0, 5, ErrorMessage = "Värdet måste vara mellan 0 och 5")]
        public int? RatingScore { get; set; }
    }
}
