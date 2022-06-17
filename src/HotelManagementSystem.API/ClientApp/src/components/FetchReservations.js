import React, { useRef } from 'react';
import { useFetch } from './useFetch';
import { Link } from 'react-router-dom';

 export const FetchReservations = () => {
  const isComponentMounted = useRef(true);

  const { data, loading, error } = useFetch(
    "reservation/reservations",
    isComponentMounted,
    []
  );
  
  if (loading) return <h1>Loading...</h1>;

  if (error) console.log(error);

  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Guest Name</th>
            <th>Room Number</th>
            <th>Check-in Date</th>
            <th>Check-out Date</th>
            <th>Number Of Nights</th>
            <th>Number of Guests</th>
            <th>Total Amount</th>
            <th>Amount Paid</th>
            <th>Total Remaining</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {data?.map(reservation =>
            <tr key={reservation.reservationId}>
              <td>{reservation.guestName}</td>
              <td>{reservation.guestName}</td>
              <td>{reservation.roomNumber}</td>
              <td>{reservation.checkInDate}</td>
              <td>{reservation.checkOutDate}</td>
              <td>{reservation.numberOfNights}</td>
              <td>{reservation.numberOfGuests}</td>
              <td>{reservation.totalAmount}</td>
              <td>{reservation.amountPaid}</td>
              <td>{reservation.totalRemaining}</td>
              <td><Link to={{pathname:"/fetch-reservation", state: {id: reservation.reservationId }}} className="btn btn-primary">Reservation</Link></td>
              <td><Link to={{pathname:"/fetch-payment", state: {id: reservation.reservationId }}} className="btn btn-primary">Payment</Link></td>
            </tr>
          )}
        </tbody>
      </table>
  )
}