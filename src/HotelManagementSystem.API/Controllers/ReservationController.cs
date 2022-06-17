using HotelManagementSystem.API.DTOs;
using HotelManagementSystem.API.Models;
using HotelManagementSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservation;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationService reservation, ILogger<ReservationController> logger)
        {
            _reservation = reservation;
            _logger = logger;
        }

        [HttpGet("reservations")]
        public async Task<ActionResult<IEnumerable<GetReservation>>> GetReservations()
        {
            try
            {
                var reservations = await _reservation.GetAllCurrentReservations();

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{reservationId}")]
        public async Task<ActionResult<GetReservation>> GetReservation(Guid reservationId)
        {
            try
            {
                var reservation = await _reservation.GetReservationById(reservationId);

                return Ok(reservation);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<GetReservation>> GetReservationByDate(DateTime date)
        {
            try
            {
                var reservations = await _reservation.GetReservationsByDate(date);

                return Ok(reservations);
            }
            catch(Exception ex)
            {
                _logger?.LogError(ex.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<Guid> Post(Reservation reservation)
        {
            try
            {
                var id = _reservation.CreateReservation(reservation);

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
