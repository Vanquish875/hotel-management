import React, { useRef } from 'react';
import { useFetch } from './useFetch';
import { useLocation, Link } from 'react-router-dom';

 export const FetchReservation = () => {
  const isComponentMounted = useRef(true);
  const location = useLocation();
  const id = location.state?.id;

  const { data, loading, error } = useFetch(
    "reservation/id/" + id,
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
            <th></th>
          </tr>
        </thead>
        <tbody>
            <tr key={data.reservationId}>
              <td>{data.guestName}</td>
              <td>{data.roomNumber}</td>
              <td>{data.checkInDate}</td>
              <td>{data.checkOutDate}</td>
              <td>{data.numberOfNights}</td>
              <td>{data.numberOfGuests}</td>
              <td>{data.totalAmount}</td>
              <td>{data.amountPaid}</td>
              <td>{data.totalRemaining}</td>
              <td><Link to={{pathname:"/edit-reservation", state: {id: data.reservationId }}} className="btn btn-primary">Edit</Link></td>
              <td><button className="btn btn-primary">Delete</button></td>
              <td><button className="btn btn-primary">Print</button></td>
            </tr>
        </tbody>
      </table>
  )
}