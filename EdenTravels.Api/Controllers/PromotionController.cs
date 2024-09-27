using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        private readonly ILogger<PromotionController> _logger;

        public PromotionController(IPromotionService promotionService, ILogger<PromotionController> logger)
        {
            _promotionService = promotionService;
            _logger = logger;
        }

        // Get all promotions for a specific tour
        [HttpGet("{tourId}")]
        public async Task<IActionResult> GetPromotionsForTour(int tourId)
        {
            try
            {
                var promotions = await _promotionService.GetPromotionsForTourAsync(tourId);
                return Ok(promotions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching promotions for tour with ID {tourId}");
                return StatusCode(500, "Internal server error");
            }
        }

        // Create a new promotion
        [HttpPost]
        public async Task<IActionResult> CreatePromotion([FromBody] PromotionDto promotionDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var createdPromotion = await _promotionService.CreatePromotionAsync(promotionDto);
                return CreatedAtAction(nameof(GetPromotionsForTour), new { tourId = createdPromotion.TourID }, createdPromotion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating promotion");
                return StatusCode(500, "Internal server error");
            }
        }

        // Delete a promotion by ID
        [HttpDelete("{promotionId}")]
        public async Task<IActionResult> DeletePromotion(int promotionId)
        {
            try
            {
                var deleted = await _promotionService.DeletePromotionAsync(promotionId);
                if (!deleted) return NotFound($"Promotion with ID {promotionId} not found");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting promotion with ID {promotionId}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}