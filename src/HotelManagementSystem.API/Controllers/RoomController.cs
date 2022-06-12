using HotelManagementSystem.API.Models;
using HotelManagementSystem.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.API.DTOs;
using HotelManagementSystem.API.Models.Search;

namespace HotelManagementSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _room;
        private readonly ILogger<RoomController> _logger;
        public RoomController(ILogger<RoomController> logger, IRoomService room)
        {
            _logger = logger;
            _room = room;
        }

        [HttpGet("rooms")]
        public async Task<ActionResult<IEnumerable<Room>>> Get()
        {
            try
            {
                var rooms = await _room.GetAllRooms();

                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("rooms/search/{roomSearch}")]
        public async Task<ActionResult<IEnumerable<GetRoom>>> GetRoomBySearchCriteria(RoomSearch roomSearch)
        {
            try
            {
                var rooms = await _room.GetRoomsAvailableBySearchCriteria(roomSearch);

                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
