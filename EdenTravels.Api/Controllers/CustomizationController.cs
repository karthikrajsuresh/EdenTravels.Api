using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomizationController : ControllerBase
    {
        private readonly ICustomizationService _customizationService;
        private readonly ILogger<CustomizationController> _logger;

        public CustomizationController(ICustomizationService customizationService, ILogger<CustomizationController> logger)
        {
            _customizationService = customizationService;
            _logger = logger;
        }

        [HttpGet("{tourId}")]
        public async Task<IActionResult> GetCustomizationsForTour(int tourId)
        {
            try
            {
                var customizations = await _customizationService.GetCustomizationsForTourAsync(tourId);
                return Ok(customizations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching customizations for tour with ID {tourId}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomization([FromBody] CustomizationDto customizationDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var createdCustomization = await _customizationService.CreateCustomizationAsync(customizationDto);
                return CreatedAtAction(nameof(GetCustomizationsForTour), new { tourId = createdCustomization.TourID }, createdCustomization);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating customization");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}