namespace HotelManagementSystem.API.DTOs
{
    public class GetRoom
    {
        public Guid RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int MaxPersons { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}
