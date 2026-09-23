using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoWell.DTO;
using MoWell.Interfaces;
using MoWell.Service;
using System.Security.Claims;

namespace MoWell.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HealthLogController : ControllerBase
    {
        private readonly IHealthLogService _healthLogService;

        public HealthLogController(IHealthLogService healthLogService)
        {
            _healthLogService = healthLogService;
        }

        [HttpPost]
        public async Task<ActionResult<HealthLogDto>> Create(HealthLogRequestDto dto)
        {
            var createdLog = await _healthLogService.CreateHealthLog(GetUserId(), dto);
            return CreatedAtAction(nameof(GetById), new { logId = createdLog.Id }, createdLog);
        }

        [HttpGet]
        public async Task<ActionResult<List<HealthLogDto>>> GetAll()
        {
            var healthLogs = await _healthLogService.GetAllHealthLogs(GetUserId());
            return Ok(healthLogs);
        }

        [HttpGet("{logId:int:min(1)}")]
        public async Task<ActionResult<HealthLogDto>> GetById(int logId)
        {
            var log = await _healthLogService.GetHealthLogById(GetUserId(), logId);
            return Ok(log);
        }

        [HttpPut("{logId:int:min(1)}")]
        public async Task<IActionResult> Edit(int logId, HealthLogRequestDto editHealthLog)
        {
            await _healthLogService.EditHealthLog(GetUserId(), logId, editHealthLog);
            return NoContent();
        }

        [HttpDelete("{logId:int:min(1)}")]
        public async Task<IActionResult> Delete(int logId)
        {
            await _healthLogService.DeleteHealthLog(GetUserId(), logId);
            return NoContent();
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }        
    }
}
