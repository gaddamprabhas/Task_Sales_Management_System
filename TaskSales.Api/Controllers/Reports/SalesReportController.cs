// Week 9 Day 3 - Sales Analytics API
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSales.Application.Interfaces;

namespace TaskSales.Api.Controllers.Reports
{
    [ApiController]
    [Route("api/reports")]
    [Authorize(Roles = "Admin")]
    public class SalesReportController : ControllerBase
    {
        private readonly ISalesReportService _reportService;

        public SalesReportController(ISalesReportService reportService)
        {
            _reportService = reportService;
        }

        // ✅ GET: api/reports/sales-by-employee
        [HttpGet("sales-by-employee")]
        public async Task<IActionResult> GetSalesByEmployee()
        {
            var data = await _reportService.GetSalesByEmployeeAsync();
            return Ok(data);
        }
       
    }
}
