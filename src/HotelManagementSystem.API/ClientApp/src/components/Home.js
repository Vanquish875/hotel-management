import React from "react";
import moment from "moment";
import { FetchReservationByDate } from './FetchReservationByDate';

export const Home = () => {
  const currentDateTime = moment().format("YYYY-MM-DD hh:mm:ss");
  const currentDate = moment().format("DD-MM-YYYY");

  return (
    <div>
      <h5>Date: {currentDate}</h5>
      <FetchReservationByDate date={currentDateTime} />
    </div>
  )
}