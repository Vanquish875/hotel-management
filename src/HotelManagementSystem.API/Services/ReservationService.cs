using HotelManagementSystem.API.DataManager;
using HotelManagementSystem.API.DTOs;
using HotelManagementSystem.API.Models;
using HotelManagementSystem.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly DataContext _context;

        public ReservationService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetReservation>> GetAllCurrentReservations()
        {
            var reservations = await (from reservation in _context.Reservations
                                join guest in _context.Guests on reservation.GuestId equals guest.GuestId
                                join room in _context.Rooms on reservation.RoomId equals room.RoomId
                                where reservation.CheckInDate < DateTime.Now && reservation.CheckOutDate < DateTime.Now
                                select new GetReservation
                                {
                                    ReservationId = reservation.ReservationId,
                                    GuestName = $"{guest.FirstName} {guest.LastName}",
                                    RoomNumber = room.RoomNumber,
                                    CheckInDate = reservation.GetCheckinDateTime(),
                                    CheckOutDate = reservation.GetCheckOutDateTime(),
                                    NumberOfNights = reservation.GetTotalAmountOfDays(),
                                    NumberOfGuests = reservation.NumberOfAdults + reservation.NumberOfChildren,
                                    TotalAmount = room.PricePerNight * reservation.GetTotalAmountOfDays(),
                                    AmountPaid = 0.0M,
                                    TotalRemaining = 0.0M
                                })
                                .AsNoTracking()
                                .ToListAsync();

            ArgumentNullException.ThrowIfNull(reservations, nameof(reservations));

            var payments = await _context.Payments
                .AsNoTracking()
                .ToListAsync();

            foreach (var reservation in reservations)
            {
                var totalPaid = payments
                    .Where(p => p.ReservationId == reservation.ReservationId)
                    .Sum(s => s.Amount);

                reservation.AmountPaid = totalPaid;
                reservation.TotalRemaining = reservation.TotalAmount - totalPaid;
            }

            return reservations;
        }

        public async Task<IEnumerable<GetReservation>> GetAllUpcomingReservations()
        {
            var reservations = await (from reservation in _context.Reservations
                                      join guest in _context.Guests on reservation.GuestId equals guest.GuestId
                                      join room in _context.Rooms on reservation.RoomId equals room.RoomId
                                      where reservation.CheckInDate > DateTime.Now
                                      select new GetReservation
                                      {
                                          ReservationId = reservation.ReservationId,
                                          GuestName = $"{guest.FirstName} {guest.LastName}",
                                          RoomNumber = room.RoomNumber,
                                          CheckInDate = reservation.GetCheckinDateTime(),
                                          CheckOutDate = reservation.GetCheckOutDateTime(),
                                          NumberOfNights = reservation.GetTotalAmountOfDays(),
                                          NumberOfGuests = reservation.NumberOfAdults + reservation.NumberOfChildren,
                                          TotalAmount = room.PricePerNight * reservation.GetTotalAmountOfDays(),
                                          AmountPaid = 0.0M,
                                          TotalRemaining = 0.0M
                                      }).AsNoTracking()
                                      .ToListAsync();

            ArgumentNullException.ThrowIfNull(reservations, nameof(reservations));

            var payments = await _context.Payments
                .AsNoTracking()
                .ToListAsync();

            foreach (var reservation in reservations)
            {
                var totalPaid = payments
                    .Where(p => p.ReservationId == reservation.ReservationId)
                    .Sum(s => s.Amount);

                reservation.AmountPaid = totalPaid;
                reservation.TotalRemaining = reservation.TotalAmount - totalPaid;
            }

            return reservations;
        }

        public async Task<IEnumerable<GetReservation>> GetAllPastReservations()
        {
            var reservations = await (from reservation in _context.Reservations
                                join guest in _context.Guests on reservation.GuestId equals guest.GuestId
                                join room in _context.Rooms on reservation.RoomId equals room.RoomId
                                where reservation.CheckOutDate < DateTime.Now
                                select new GetReservation
                                {
                                    ReservationId = reservation.ReservationId,
                                    GuestName = $"{guest.FirstName} {guest.LastName}",
                                    RoomNumber = room.RoomNumber,
                                    CheckInDate = reservation.GetCheckinDateTime(),
                                    CheckOutDate = reservation.GetCheckOutDateTime(),
                                    NumberOfNights = reservation.GetTotalAmountOfDays(),
                                    NumberOfGuests = reservation.NumberOfAdults + reservation.NumberOfChildren,
                                    TotalAmount = room.PricePerNight * reservation.GetTotalAmountOfDays(),
                                    AmountPaid = 0.0M,
                                    TotalRemaining = 0.0M
                                })
                                .AsNoTracking()
                                .ToListAsync();

            ArgumentNullException.ThrowIfNull(reservations, nameof(reservations));

            var payments = await _context.Payments
                .AsNoTracking()
                .ToListAsync();

            foreach (var reservation in reservations)
            {
                var totalPaid = payments
                    .Where(p => p.ReservationId == reservation.ReservationId)
                    .Sum(s => s.Amount);

                reservation.AmountPaid = totalPaid;
                reservation.TotalRemaining = reservation.TotalAmount - totalPaid;
            }

            return reservations;
        }

        public async Task<GetReservation> GetReservationById(Guid reservationId)
        {
            var payments = _context.Payments.Where(p => p.ReservationId == reservationId);
            var totalPaid = 0.0M;

            if(payments is not null)
            {
                totalPaid = payments.Sum(p => p.Amount);
            }

            var reservation = (from res in _context.Reservations
                               join guest in _context.Guests on res.GuestId equals guest.GuestId
                               join room in _context.Rooms on res.RoomId equals room.RoomId
                               where res.ReservationId == reservationId
                               select new GetReservation
                               {
                                   ReservationId = res.ReservationId,
                                   GuestName = $"{guest.FirstName} {guest.LastName}",
                                   RoomNumber = room.RoomNumber,
                                   CheckInDate = res.GetCheckinDateTime(),
                                   CheckOutDate = res.GetCheckOutDateTime(),
                                   NumberOfNights = res.GetTotalAmountOfDays(),
                                   NumberOfGuests = res.NumberOfAdults + res.NumberOfChildren,
                                   TotalAmount = room.PricePerNight * res.GetTotalAmountOfDays(),
                                   AmountPaid = totalPaid,
                                   TotalRemaining = room.PricePerNight * res.GetTotalAmountOfDays() - totalPaid
                               }).AsNoTracking();

            ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

            return await reservation.FirstAsync();
        }

        public async Task<IEnumerable<GetReservation>> GetReservationsByDate(DateTime date)
        {
            var reservations = await (from res in _context.Reservations
                               join guest in _context.Guests on res.GuestId equals guest.GuestId
                               join room in _context.Rooms on res.RoomId equals room.RoomId
                               where res.CheckInDate.Date == date.Date
                               select new GetReservation
                               {
                                   ReservationId = res.ReservationId,
                                   GuestName = $"{guest.FirstName} {guest.LastName}",
                                   RoomNumber = room.RoomNumber,
                                   CheckInDate = res.GetCheckinDateTime(),
                                   CheckOutDate = res.GetCheckOutDateTime(),
                                   NumberOfNights = res.GetTotalAmountOfDays(),
                                   NumberOfGuests = res.NumberOfAdults + res.NumberOfChildren,
                                   TotalAmount = room.PricePerNight * res.GetTotalAmountOfDays(),
                                   AmountPaid = 0.0M,
                                   TotalRemaining = 0.0M
                               })
                               .AsNoTracking()
                               .ToListAsync();

            ArgumentNullException.ThrowIfNull(reservations, "No reservations for this Date:");

            var payments = await _context.Payments
                .AsNoTracking()
                .ToListAsync();

            foreach (var reservation in reservations)
            {
                var totalPaid = payments
                    .Where(p => p.ReservationId == reservation.ReservationId)
                    .Sum(s => s.Amount);

                reservation.AmountPaid = totalPaid;
                reservation.TotalRemaining = reservation.TotalAmount - totalPaid;
            }

            return reservations;
        }

        public Guid CreateReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

            var payment = reservation.Payments.First();

            payment.ReservationId = reservation.ReservationId;
            payment.GuestId = reservation.GuestId;

            reservation.Payments.Add(payment);

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return reservation.ReservationId;
        }

        public Guid UpdateReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

            _context.Reservations.Update(reservation);
            _context.SaveChanges();

            return reservation.ReservationId;
        }

        public void DeleteReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
