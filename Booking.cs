using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Booking
    {
        // Booking Fields
        private Room bookedRoom;
        private Guest bookingGuest;
        private DateTime BookingTime;
        // A constructor that takes a Room and a Guest
        public Booking(Room room, Guest guest)
        {
            
            // Check if the room is already booked
            if (room.IsBooked)
            {
                Console.WriteLine("Room is already booked");
            }
            else
            {
                bookedRoom = room;
                bookingGuest = guest;
                BookingTime = DateTime.Now;
                Console.WriteLine($"Booking created for Room Number: {room.RoomNumber} and Guest National ID: {guest.National_ID}");
            }
        }

        /*A method ConfirmBooking() that: 
        ▪ Checks if the room is booked 
        ▪ If not, books the room and prints guest name and room number 
        */

        public void ConfirmBooking()
        {
            if (!bookedRoom.IsBooked) // 1.Checks if the room is booked
            {
                // 2.If not, books the room and prints guest name and room number
                bookedRoom.Book();
                this.BookingTime = DateTime.Today; //10. Sets the booking time to the current time

                Console.WriteLine("Booking Time is : " + BookingTime);
                Console.WriteLine("Booking confirmed for " + bookingGuest.Name + " in room " + bookedRoom.RoomNumber);
            }
            else
            {
                Console.WriteLine("Room " + bookedRoom.RoomNumber + " is already booked");
            }

        }
        
    }
}
