using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;
        public ScheduleController(IScheduleService service, AppDbContext db)
        {
            _service = service;
        }
        // GET: api/schedule/group/{groupName}?start=2026-01-12&end=2026-01-17
        [HttpGet("group/{groupName}")]
        public async Task<IActionResult> GetSchedule(string groupName, DateTime start, DateTime end)
        {
            // Вызываем бизнес-логику из сервиса
            var result = await _service.GetScheduleForGroup(groupName, start.Date, end.Date);
            // Возвращаем результат со статусом 200 OK
            return Ok(result);
        }
        [HttpGet("groups")]
        public async Task<ActionResult<List<string>>> GetGroups()
        {
            var groups = await _service.GetAllGroupsAsync();
            return Ok(groups);
        }
    }
}