using MoWell.Models;

namespace MoWell.Interfaces
{
    public interface IHealthLogRepository
    {
        Task<List<HealthLog>> GetAllHealthLogs(string userId);
        Task<HealthLog> GetHealthLogById(int id);
        Task<HealthLog> CreateHealthLog(string userId, DateTime dateTime, LogType type, int value);
        Task<HealthLog> EditHealthLog(int id, DateTime dateTime, LogType type, int value);
        Task DeleteHealthLog(int id);
    }
}
