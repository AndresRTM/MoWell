using MoWell.DTO;
using MoWell.Interfaces;
using MoWell.Models;

namespace MoWell.Service
{
    public class HealthLogService : IHealthLogService
    {
        private readonly IHealthLogRepository _repository;

        public HealthLogService(IHealthLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<HealthLogDto> CreateHealthLog(string userId, HealthLogRequestDto dto)
        {
            var utcDateTime = ToUtc(dto.DateTime.Value);
            ValidateNotInFuture(utcDateTime);
            var newHealthLog = await _repository.CreateHealthLog(userId, utcDateTime, dto.Type.Value, dto.RatingScore.Value);
            return MapToHealthLogDto(newHealthLog);
        }

        public async Task<List<HealthLogDto>> GetAllHealthLogs(string userId)
        {
            var healthLogs = await _repository.GetAllHealthLogs(userId);
            return healthLogs.Select(MapToHealthLogDto).ToList();
        }

        public async Task<HealthLogDto> GetHealthLogById(string userId, int id)
        {
            var healthLog = await GetAndValidateHealthLog(id, userId);
            return MapToHealthLogDto(healthLog);
        }

        public async Task<HealthLogDto> EditHealthLog(string userId, int id, HealthLogRequestDto dto)
        {
            var utcDateTime = ToUtc(dto.DateTime.Value);
            ValidateNotInFuture(utcDateTime);
            await GetAndValidateHealthLog(id, userId);
            var updatedHealthLog = await _repository.EditHealthLog(id, utcDateTime, dto.Type.Value, dto.RatingScore.Value);
            return MapToHealthLogDto(updatedHealthLog);
        }

        public async Task DeleteHealthLog(string userId, int id)
        {
            await GetAndValidateHealthLog(id, userId);
            await _repository.DeleteHealthLog(id);
        }

        private async Task<HealthLog> GetAndValidateHealthLog(int id, string userId)
        {
            var healthLog = await _repository.GetHealthLogById(id);

            if (healthLog == null)
            {
                throw new Exception("Loggen hittades inte");
            }

            if (healthLog.UserId != userId)
            {
                throw new UnauthorizedAccessException("Du har inte behörighet");
            }

            return healthLog;
        }


        private DateTime ToUtc(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc)
            {
                return dateTime;
            }

            if (dateTime.Kind == DateTimeKind.Local)
            {
                return dateTime.ToUniversalTime();
            }

            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }

        private void ValidateNotInFuture(DateTime utcDateTime)
        {
            if (utcDateTime > DateTime.UtcNow.AddMinutes(1))
            {
                throw new ArgumentException("Du kan inte logga i framtiden");
            }
        }

        private HealthLogDto MapToHealthLogDto(HealthLog healthLog)
        {
            return new HealthLogDto
            {
                Id = healthLog.Id,
                DateTime = healthLog.DateTime,
                Type = healthLog.Type,
                RatingScore = healthLog.RatingScore
            };
        }
    }
}
