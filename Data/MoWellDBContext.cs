using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoWell.Models;

namespace MoWell.Data
{
    public class MoWellDBContext : IdentityDbContext<User>
    {
        public MoWellDBContext(DbContextOptions<MoWellDBContext> options) : base(options)
        {

        }

        public DbSet<HealthLog> HealthLogs { get; set; }


    }
}
