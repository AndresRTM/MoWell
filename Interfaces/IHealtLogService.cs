using MoWell.DTO;
using MoWell.Models;

namespace MoWell.Interfaces
{
    public interface IHealtLogService
    {
        Task<HealthLogDto> CreateHealthLog(string userId, HealthLogRequestDto dto);
        Task<List<HealthLogDto>> GetAllHealthLogs(string userId);
        Task<HealthLogDto> GetHealthLogById(string userId, int id) ;
        Task<HealthLogDto> EditHealthLog(string userId, int id, HealthLogRequestDto dto);
        Task DeleteHealthLog(string userID, int id);
    }
}
