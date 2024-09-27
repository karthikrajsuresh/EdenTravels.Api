using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ILogger<FeedbackController> _logger;

        public FeedbackController(IFeedbackService feedbackService, ILogger<FeedbackController> logger)
        {
            _feedbackService = feedbackService;
            _logger = logger;
        }

        [HttpGet("{tourId}")]
        public async Task<IActionResult> GetFeedbackForTour(int tourId)
        {
            try
            {
                var feedbacks = await _feedbackService.GetFeedbackForTourAsync(tourId);
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching feedback for tour with ID {tourId}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackDto feedbackDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _feedbackService.SubmitFeedbackAsync(feedbackDto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while submitting feedback");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}