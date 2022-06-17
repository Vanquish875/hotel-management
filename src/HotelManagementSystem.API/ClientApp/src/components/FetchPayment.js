import React, { useRef } from 'react';
import { useFetch } from './useFetch';
import { useLocation } from 'react-router-dom';

export const FetchPayment = () => {
  const isComponentMounted = useRef(true);
  const location = useLocation();
  const id = location.state?.id;

  const { data, loading, error } = useFetch(
    "payment/id/" + id,
    isComponentMounted,
    []
  );

  if (loading) return <h1>Loading...</h1>;

  if (error) console.log(error);
  
  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Guest ID</th>
          <th>Reservation ID</th>
          <th>Amount</th>
          <th>Payment Date</th>
        </tr>
      </thead>
      <tbody>
        {data?.map(payment =>
          <tr key={payment.paymentId}>
            <td>{payment.guestId}</td>
            <td>{payment.reservationId}</td>
            <td>{payment.amount}</td>
            <td>{payment.paymentDate}</td>
          </tr>
        )}
      </tbody>
    </table>
  )
}