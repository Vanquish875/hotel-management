import React, { useRef } from 'react';
import { useFetch } from './useFetch';

export const FetchRooms = () =>  {
  const isComponentMounted = useRef(true);

  const { data, loading, error } = useFetch(
    "room/rooms",
    isComponentMounted,
    []
  );

  if (loading) return <h1>Loading...</h1>;

  if (error) console.log(error);

  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
    <thead>
      <tr>
        <th>Room Number</th>
        <th>Room Type</th>
        <th>Price</th>
        <th>Max Persons</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      {data?.map(room =>
        <tr key={room.roomId}>
          <td>{room.roomNumber}</td>
          <td>{room.roomType}</td>
          <td>{room.pricePerNight}</td>
          <td>{room.maxPersons}</td>
          <img src={room.imagePath}></img>
        </tr>
      )}
    </tbody>
  </table>
  )
}
