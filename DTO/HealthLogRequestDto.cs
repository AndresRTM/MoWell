using MoWell.Models;
using System.ComponentModel.DataAnnotations;

namespace MoWell.DTO
{
    public class HealthLogRequestDto
    {
        [Required(ErrorMessage = "Date and time is required")]
        public DateTime? DateTime { get; set; }

        [Required(ErrorMessage = "Typ måste anges")]
        [EnumDataType(typeof(LogType), ErrorMessage = "Invalid log type")]
        public LogType? Type { get; set; }

        [Required(ErrorMessage = "Värdet måste anges")]
        [Range(0, 5, ErrorMessage = "Rating score must be between 0 and 5")]
        public int? RatingScore { get; set; }
    }
}
