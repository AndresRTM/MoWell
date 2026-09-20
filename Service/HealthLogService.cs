using MoWell.DTO;
using MoWell.Interfaces;

namespace MoWell.Service
{
    public class HealthLogService : IHealtLogService
    {
        private readonly IHealtLogRepository _repository;

        public HealthLogService (IHealtLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<HealthLogDto> CreateHealthLog(string userId, HealthLogRequestDto dto)
        {
            if(dto.Value < 0 || dto.Value > 5)
            {
                throw new ArgumentOutOfRangeException("Invalid value, the value must be in the range of 0-5");
            }

            if (dto.DateTime > DateTime.UtcNow)
            {
                throw new ArgumentException("Date and time cant be changed");
            }

            var newHealtLog = await _repository.CreateHealthLog(userId, dto.DateTime, dto.Type, dto.Value);

            return new HealthLogDto
            { Id = newHealtLog.Id,
              DateTime = newHealtLog.DateTime,
              Type = dto.Type,
              Value = dto.Value,
            };
        }

        public Task DeleteHealthLog(string userID, int id)
        {
            throw new NotImplementedException();
        }

        public Task<HealthLogDto> EditHealthLog(string userId, int id, HealthLogRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<HealthLogDto>> GetAllHealthLogs(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<HealthLogDto> GetHealthLogById(string userId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
