using Microsoft.AspNetCore.Mvc;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;
[ApiController]
[Route("api/employees")]

    // 🔥 FIX: force lowercase
    public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
    {
        await _service.AddAsync(dto);
        return Ok();
    }

    [HttpPost("ensure")]
    public async Task<IActionResult> Ensure([FromBody] EmployeeDto dto)
    {
        var exists = await _service.GetByIdentityIdAsync(dto.IdentityUserId);
        if (exists != null)
            return Ok(exists);

        await _service.AddAsync(dto);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeDto dto)
    {
        dto.Id = id;
        await _service.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("identity/{identityId}")]
    public async Task<IActionResult> GetByIdentity(string identityId)
    {
        var emp = await _service.GetByIdentityIdAsync(identityId);
        if (emp == null) return NotFound();
        return Ok(emp);
    }
    [HttpGet("by-identity/{identityId}")]
    public async Task<ActionResult<int>> GetEmployeeIdByIdentity(string identityId)
    {
        var emp = await _service.GetByIdentityIdAsync(identityId);
        if (emp == null) return NotFound();
        return Ok(emp.Id);
    }


}
