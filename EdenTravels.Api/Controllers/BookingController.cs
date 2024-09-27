using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingService bookingService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsAsync();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching bookings");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            try
            {
                var booking = await _bookingService.GetBookingByIdAsync(id);
                if (booking == null) return NotFound($"Booking with ID {id} not found");
                return Ok(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching booking with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var createdBooking = await _bookingService.CreateBookingAsync(bookingDto);
                return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.BookingID }, createdBooking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating booking");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] BookingDto bookingDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var updatedBooking = await _bookingService.UpdateBookingAsync(id, bookingDto);
                if (updatedBooking == null) return NotFound($"Booking with ID {id} not found");
                return Ok(updatedBooking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating booking with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var deleted = await _bookingService.DeleteBookingAsync(id);
                if (!deleted) return NotFound($"Booking with ID {id} not found");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting booking with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/participants")]
        public async Task<IActionResult> GetBookingParticipants(int id)
        {
            try
            {
                var participants = await _bookingService.GetBookingParticipantsAsync(id);
                if (participants == null || participants.Count == 0) return NotFound($"No participants found for booking with ID {id}");
                return Ok(participants);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching participants for booking with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/passport-visa-status")]
        public async Task<IActionResult> GetPassportVisaStatus(int id)
        {
            try
            {
                var status = await _bookingService.GetPassportVisaStatusAsync(id);
                if (status == null) return NotFound($"No passport/visa status found for booking with ID {id}");
                return Ok(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching passport/visa status for booking with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}