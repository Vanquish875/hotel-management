import React, { useRef } from 'react';
import { useFetch } from './useFetch';

export const FetchReservationByDate = (props) => {
    const isComponentMounted = useRef(true);

    const { data, loading, error } = useFetch(
        "reservation/date/" + props.date,
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
            <th>Number Of Guests</th>
            <th>Total Amount</th>
            <th>Amount Paid</th>
            <th>Total Remaining</th>
          </tr>
        </thead>
        <tbody>
          {data?.map(reservation =>
            <tr key={reservation.reservationId}>
              <td>{reservation.guestName}</td>
              <td>{reservation.roomNumber}</td>
              <td>{reservation.checkInDate}</td>
              <td>{reservation.checkOutDate}</td>
              <td>{reservation.numberOfNights}</td>
              <td>{reservation.numberOfGuests}</td>
              <td>{reservation.totalAmount}</td>
              <td>{reservation.amountPaid}</td>
              <td>{reservation.totalRemaining}</td>
            </tr>
          )}
        </tbody>
      </table>
  )
}