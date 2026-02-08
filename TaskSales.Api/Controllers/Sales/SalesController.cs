using Microsoft.AspNetCore.Mvc;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;

namespace TaskSales.Api.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // GET: /api/sales
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _saleService.GetAllAsync();
            return Ok(sales);
        }

        // POST: /api/sales
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleDto sale)
        {
            if (sale == null)
                return BadRequest("Sale data is required");

            await _saleService.AddAsync(sale);
            return Ok(new { message = "Sale added successfully" });
        }
    }
}
