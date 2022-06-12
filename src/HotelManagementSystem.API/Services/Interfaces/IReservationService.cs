using HotelManagementSystem.API.DTOs;
using HotelManagementSystem.API.Models;

namespace HotelManagementSystem.API.Services.Interfaces
{
    public interface IReservationService
    {
        Guid CreateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Task<IEnumerable<GetReservation>> GetAllReservations();
        Task<GetReservation> GetReservationById(Guid reservationId);
        Task<IEnumerable<GetReservation>> GetReservationsByDate(DateTime date);
        void UpdateReservation(Reservation reservation);
    }
}