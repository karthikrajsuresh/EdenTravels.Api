using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly ILogger<TourController> _logger;

        public TourController(ITourService tourService, ILogger<TourController> logger)
        {
            _tourService = tourService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTours()
        {
            try
            {
                var tours = await _tourService.GetAllToursAsync();
                return Ok(tours);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching tours");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTourById(int id)
        {
            try
            {
                var tour = await _tourService.GetTourByIdAsync(id);
                if (tour == null) return NotFound($"Tour with ID {id} not found");
                return Ok(tour);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching tour with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTour([FromBody] TourDto tourDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var createdTour = await _tourService.CreateTourAsync(tourDto);
                return CreatedAtAction(nameof(GetTourById), new { id = createdTour.TourID }, createdTour);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating tour");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTour(int id, [FromBody] TourDto tourDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var updatedTour = await _tourService.UpdateTourAsync(id, tourDto);
                if (updatedTour == null) return NotFound($"Tour with ID {id} not found");
                return Ok(updatedTour);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while updating tour with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id)
        {
            try
            {
                var deleted = await _tourService.DeleteTourAsync(id);
                if (!deleted) return NotFound($"Tour with ID {id} not found");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting tour with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/dynamic-pricing")]
        public async Task<IActionResult> GetDynamicPricing(int id)
        {
            try
            {
                var pricing = await _tourService.GetDynamicPricingForTourAsync(id);
                if (pricing == null) return NotFound($"No dynamic pricing available for tour with ID {id}");
                return Ok(pricing);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching dynamic pricing for tour with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}