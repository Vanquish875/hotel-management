using HotelManagementSystem.API.Models;
using HotelManagementSystem.API.DTOs;
using HotelManagementSystem.API.Models.Search;

namespace HotelManagementSystem.API.Services.Interfaces
{
    public interface IRoomService
    {
        void CreateRoom(Room room);
        void DeleteRoom(Room room);
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> GetRoomById(Guid roomId);
        Task<IEnumerable<GetRoom>> GetRoomsAvailableBySearchCriteria(RoomSearch roomSearch);
        void UpdateRoom(Room room);
    }
}