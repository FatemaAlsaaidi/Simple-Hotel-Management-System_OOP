using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Booking
    {
        // A constructor that takes a Room and a Guest
        public Booking(Room roomNumber, Guest GuestNationalID) 
        {
           Console.WriteLine($"Booking created for Room Number: {roomNumber} and Guest National ID: {GuestNationalID}");
        }
        /*A method ConfirmBooking() that: 
        ▪ Checks if the room is booked 
        ▪ If not, books the room and prints guest name and room number 
        */
        public void ConfirmBooking(Room room, Guest guest)
        {
            if (!room.IsBooked)
            {
                room.Book();
                Console.WriteLine($"Booking confirmed for Guest: {guest.Name} in Room Number: {room.RoomNumber}");
            }
            else
            {
                Console.WriteLine("Room is already booked. Cannot confirm booking.");
            }
        }
        
    }
}
