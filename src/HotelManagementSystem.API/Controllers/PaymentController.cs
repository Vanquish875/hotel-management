using HotelManagementSystem.API.Models;
using HotelManagementSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _payment;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService payment)
        {
            _payment = payment;
            _logger = logger;
        }

        [HttpGet("payments")]
        public async Task<ActionResult<IEnumerable<Payment>>> Get()
        {
            try
            {
                var payments = await _payment.GetAllPayments();

                return Ok(payments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{reservationId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentByReservationId(Guid reservationId)
        {
            try
            {
                var payments = await _payment.GetPaymentsByReservationId(reservationId);

                return Ok(payments);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
