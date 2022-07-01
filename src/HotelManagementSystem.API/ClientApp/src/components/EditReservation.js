import React, { useRef } from 'react';
import { useFetch } from './useFetch';
import { useLocation } from 'react-router-dom';
import { useForm } from 'react-hook-form';
import axios from 'axios';

export const EditReservation = () => {
    const { register, handleSubmit, formState: { errors } } = useForm({});
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

    const onSubmit = async (reservation) => {

        let reserve = {
            GuestId: reservation.guestId,
            RoomId: reservation.roomId,
            CheckInDate: reservation.chekInDate,
            CheckOutDate: reservation.checkOutDate,
            NumberOfAdults: reservation.numberOfAdults,
            NumberOfChildren: reservation.numberOfChildren
        };

        await axios.put('reservation/id/edit', JSON.stringify(reserve), {
            headers: { 'Content-Type': 'application/json' }
        });
    }
    
    return (
    <form onSubmit={handleSubmit(onSubmit)}>
        <div class="form-group">
            <label>
                Guest ID:
                <input 
                    {...register("guestId")}
                    value={data.guestId} />
            </label>
        </div>
        <br />
        <label>
            Room Id:
            <input
                {...register("roomId")}
                value={data.roomId} />
        </label>
        <br />
        <label>
            Check In Date:
            <input
                {...register("checkInDate")}
                value={data.checkInDate} />
        </label>
        <br />
        <label>
            Check Out Date:
            <input
                {...register("checkOutDate")}
                value={data.checkOutDate} />
        </label>
        <br />
        <label>
            Number Of Adults:
            <input
                {...register("numberOfAdults")}
                value={data.numberOfAdults} />
        </label>
        <br />
        <label>
            Number of Children:
            <input
                {...register("numberOfChildren")}
                value={data.numberOfChildren} />
        </label>
        <br />                            
        <input type="submit" />
    </form>
  )
}
