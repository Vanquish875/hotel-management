import React from 'react';

export const PrintReceipt = () => {
    const receipt = {
        name: "David Harris",
        roomNumber: "302",
        checkInDate: "05/30/2022",
        checkOutDate: "06/05/2022",
        numberOfDays: 6,
        amountPerDay: 55.65,
        TotalAmount: 333.90,
        AmountPaid: 333.90,
        numberOfGuests: 2
    };

    const days = [ "05/30/2022", "05/31/2022", "06/01/2022", "06/02/2022", "06/03/2022", "06/04/2022", "06/05/2022" ];

    return (
    <div>
        <div>
            <h1>Hotel</h1>
        </div>
        <div>
            <h4>{receipt.name}</h4>
            <h6>{receipt.checkInDate}</h6>
            <h6>{receipt.checkOutDate}</h6>
        </div>
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Date:</th>
                    <th>Amount Per Day:</th>
                </tr>
            </thead>
            <tbody>
                {days.map(day => 
                    <tr>
                        <td>{day}</td>
                        <td>{receipt.amountPerDay}</td>
                    </tr>
                )}
                <tr>
                    <td>Total Amount:</td>
                    <td>{receipt.TotalAmount}</td>
                </tr>
            </tbody>
        </table>
    </div>
  )
}
