import React from 'react'

export const reservations = () => {
    
  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Guest Name</th>
            <th>Room Number</th>
            <th>Check-in Date</th>
            <th>Check-out Date</th>
            <th>Number Of Nights</th>
            <th>Total Amount</th>
            <th>Number of Guests</th>
          </tr>
        </thead>
        <tbody>
          {data?.map(reservation =>
            <tr key={reservation?.reservationId}>
              <td>{reservation?.guestName}</td>
              <td>{reservation?.roomNumber}</td>
              <td>{reservation?.checkInDate}</td>
              <td>{reservation?.checkOutDate}</td>
              <td>{reservation?.numberOfNights}</td>
              <td>{reservation?.totalAmount}</td>
              <td>{reservation?.numberOfGuests}</td>
            </tr>
          )}
        </tbody>
      </table>
  )
}