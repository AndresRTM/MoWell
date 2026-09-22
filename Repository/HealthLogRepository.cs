using Microsoft.EntityFrameworkCore;
using MoWell.Data;
using MoWell.Interfaces;
using MoWell.Models;

namespace MoWell.Repository
{
    public class HealthLogRepository : IHealthLogRepository
    {
        private readonly MoWellDBContext _context;

        public HealthLogRepository(MoWellDBContext context)
        {
            _context = context;
        }

        public async Task<HealthLog> CreateHealthLog(string userId, DateTime dateTime, LogType type, int value)
        {
            var healthtLog = new HealthLog
            {
                UserId = userId,
                DateTime = dateTime,
                Type = type,
                RatingScore = value
            };

            await _context.HealthLogs.AddAsync(healthtLog);
            await _context.SaveChangesAsync();
            return healthtLog;
        }
        public async Task<List<HealthLog>> GetAllHealthLogs(string userId)
        {
            return await _context.HealthLogs.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<HealthLog> GetHealthLogById(int id)
        {
            return await _context.HealthLogs.FindAsync(id);
        }
        public async Task<HealthLog> EditHealthLog(int id, DateTime dateTime, LogType type, int value)
        {
            var healthlog = await _context.HealthLogs.FindAsync(id);
            healthlog.DateTime = dateTime;
            healthlog.Type = type;
            healthlog.RatingScore = value;
            await _context.SaveChangesAsync();
            return healthlog;
        }

        public async Task DeleteHealthLog(int id)
        {
            var healthLog = await _context.HealthLogs.FindAsync(id);
            _context.Remove(healthLog);
            await _context.SaveChangesAsync();
        }
    }
}
