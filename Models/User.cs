using Microsoft.AspNetCore.Identity;

namespace MoWell.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<HealthLog> HealthLogs { get; set; }
    }
}
