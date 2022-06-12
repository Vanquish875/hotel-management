using HotelManagementSystem.API.DataManager;
using HotelManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.API.Services.Interfaces;
using HotelManagementSystem.API.Models.Search;
using HotelManagementSystem.API.DTOs;

namespace HotelManagementSystem.API.Services
{
    public class RoomService : IRoomService
    {
        private readonly DataContext _context;
        public RoomService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            var rooms = _context.Rooms
                .OrderBy(o => o.RoomNumber);

            return await rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(Guid roomId)
        {
            var room = await _context.Rooms.FindAsync(roomId);

            ArgumentNullException.ThrowIfNull(room, nameof(room));

            return room;
        }

        public async Task<IEnumerable<GetRoom>> GetRoomsAvailableBySearchCriteria(RoomSearch roomSearch)
        {
            var reservations = from res in _context.Reservations
                               where res.CheckInDate <= roomSearch.EndDate && res.CheckOutDate >= roomSearch.StartDate
                               select res.RoomId;

            var rooms = (from room in _context.Rooms
                         join roomType in _context.RoomTypes on room.RoomTypeId equals roomType.RoomTypeId
                         where !reservations.Contains(room.RoomId)
                         select new GetRoom
                         {
                             RoomId = room.RoomId,
                             RoomNumber = room.RoomNumber,
                             RoomType = roomType.RoomTypeName,
                             PricePerNight = room.PricePerNight,
                             MaxPersons = room.MaxPersons
                         }).AsNoTracking();

            return await rooms.ToListAsync();
        }

        public void CreateRoom(Room room)
        {
            ArgumentNullException.ThrowIfNull(room, nameof(room));

            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            ArgumentNullException.ThrowIfNull(room, nameof(room));

            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(Room room)
        {
            ArgumentNullException.ThrowIfNull(room, nameof(room));

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}
