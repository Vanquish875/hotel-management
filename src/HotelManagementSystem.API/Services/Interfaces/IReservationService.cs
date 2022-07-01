﻿using HotelManagementSystem.API.DTOs;
using HotelManagementSystem.API.Models;

namespace HotelManagementSystem.API.Services.Interfaces
{
    public interface IReservationService
    {
        Guid CreateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Task<IEnumerable<GetReservation>> GetAllCurrentReservations();
        Task<IEnumerable<GetReservation>> GetAllUpcomingReservations();
        Task<IEnumerable<GetReservation>> GetAllPastReservations();
        Task<GetReservation> GetReservationById(Guid reservationId);
        Task<IEnumerable<GetReservation>> GetReservationsByDate(DateTime date);
        Guid UpdateReservation(Reservation reservation);
    }
}