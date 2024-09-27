using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly ILogger<ReportController> _logger;

        public ReportController(IReportService reportService, ILogger<ReportController> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        // Endpoint to fetch the bookings summary report
        [HttpGet("bookings-summary")]
        public async Task<IActionResult> GetBookingsSummaryReport()
        {
            try
            {
                var report = await _reportService.GetBookingsSummaryReportAsync();
                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while generating bookings summary report");
                return StatusCode(500, "Internal server error");
            }
        }

        // Endpoint to fetch the revenue summary report
        [HttpGet("revenue-summary")]
        public async Task<IActionResult> GetRevenueSummaryReport()
        {
            try
            {
                var report = await _reportService.GetRevenueSummaryReportAsync();
                return Ok(report);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while generating revenue summary report");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}