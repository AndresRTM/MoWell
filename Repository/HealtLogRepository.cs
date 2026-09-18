using MoWell.Data;
using MoWell.Interfaces;
using MoWell.Models;

namespace MoWell.Repository
{
    public class HealtLogRepository : IHealtLogRepository
    {
        private readonly MoWellDBContext _context;

        public HealtLogRepository(MoWellDBContext context)
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
                Value = value
            };

           await _context.HealthLogs.AddAsync(healthtLog);
           await _context.SaveChangesAsync();

            return healthtLog;
        }

        public async Task DeleteHealthLog(int id)
        {
            var healthLog = _context.HealthLogs.FindAsync(id);

            _context.Remove(healthLog);

            await _context.SaveChangesAsync();


            throw new NotImplementedException();
        }

        public async Task<HealthLog> EditHealthLog(int id, LogType type, int value)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HealthLog>> GetAllHealthLogs(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<HealthLog> GetHealthLogById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
