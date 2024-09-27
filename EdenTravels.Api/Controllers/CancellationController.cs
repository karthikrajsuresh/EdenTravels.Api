using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CancellationController : ControllerBase
    {
        private readonly ICancellationService _cancellationService;
        private readonly ILogger<CancellationController> _logger;

        public CancellationController(ICancellationService cancellationService, ILogger<CancellationController> logger)
        {
            _cancellationService = cancellationService;
            _logger = logger;
        }

        // Get cancellation details by Booking ID
        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetCancellationForBooking(int bookingId)
        {
            try
            {
                var cancellation = await _cancellationService.GetCancellationByBookingIdAsync(bookingId);
                if (cancellation == null) return NotFound($"Cancellation details for booking with ID {bookingId} not found");
                return Ok(cancellation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching cancellation details for booking with ID {bookingId}");
                return StatusCode(500, "Internal server error");
            }
        }

        // Create a new cancellation for a booking
        [HttpPost]
        public async Task<IActionResult> CreateCancellation([FromBody] CancellationDto cancellationDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var createdCancellation = await _cancellationService.CreateCancellationAsync(cancellationDto);
                return CreatedAtAction(nameof(GetCancellationForBooking), new { bookingId = createdCancellation.BookingID }, createdCancellation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating cancellation");
                return StatusCode(500, "Internal server error");
            }
        }

        // Update cancellation status
        [HttpPut("{cancellationId}")]
        public async Task<IActionResult> UpdateCancellationStatus(int cancellationId, [FromBody] CancellationDto cancellationDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var updatedCancellation = await _cancellationService.UpdateCancellationStatusAsync(cancellationId, cancellationDto);
                if (updatedCancellation == null) return NotFound($"Cancellation with ID {cancellationId} not found");
                return Ok(updatedCancellation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating cancellation with ID {cancellationId}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
