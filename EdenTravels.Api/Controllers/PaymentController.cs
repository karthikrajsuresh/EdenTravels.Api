using Microsoft.AspNetCore.Mvc;
using EdenTravels.Api.IServices;
using EdenTravels.Api.DTOs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EdenTravels.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments()
        {
            try
            {
                var payments = await _paymentService.GetAllPaymentsAsync();
                return Ok(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching payments");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByIdAsync(id);
                if (payment == null) return NotFound($"Payment with ID {id} not found");
                return Ok(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching payment with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var createdPayment = await _paymentService.CreatePaymentAsync(paymentDto);
                return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.PaymentID }, createdPayment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating payment");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}