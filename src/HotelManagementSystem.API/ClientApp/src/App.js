import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchRooms } from './components/FetchRooms';
import { FetchReservations } from './components/FetchReservations';
import { FetchGuests } from './components/FetchGuests';
import { ReservationForm } from './components/ReservationForm';
import { GuestForm } from './components/GuestForm';
import { FetchReservation } from './components/FetchReservation';
import { FetchPayment } from './components/FetchPayment';
import { PrintReceipt } from './components/PrintReceipt';
import { EditReservation } from './components/EditReservation';
import './custom.css'


export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/fetch-rooms' component={FetchRooms} />
        <Route path='/fetch-reservations' component={FetchReservations} />
        <Route path='/fetch-guests' component={FetchGuests} />
        <Route path='/reservation-form' component={ReservationForm} />
        <Route path='/guest-form' component={GuestForm} />
        <Route path='/fetch-reservation' component={FetchReservation} />
        <Route path='/fetch-payment' component={FetchPayment} />
        <Route path='/receipt' component={PrintReceipt} />
        <Route path='/edit-reservation' component={EditReservation} />
      </Layout>
    );
  }
}
