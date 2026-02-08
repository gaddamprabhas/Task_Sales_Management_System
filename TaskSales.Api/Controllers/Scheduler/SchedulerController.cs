using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;

namespace TaskSales.Api.Controllers.Scheduler
{
    [ApiController]
    [Route("api/scheduler")]
    public class SchedulerController : ControllerBase
    {
        private readonly ISchedulerService _service;

        public SchedulerController(ISchedulerService service)
        {
            _service = service;
        }

        // 🔹 GET: api/scheduler
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _service.GetAllAsync();
            return Ok(events);
        }

        // 🔹 POST: api/scheduler
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SchedulerEventDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid event data");

            await _service.AddAsync(dto);
            return Ok();
        }

        // 🔹 PUT: api/scheduler/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SchedulerEventDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid event data");

            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        // 🔹 DELETE: api/scheduler/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
