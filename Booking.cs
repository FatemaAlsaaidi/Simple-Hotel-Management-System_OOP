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
        private DateTime bookingTime; // Private field for BookingTime
        public DateTime BookingTime
        {
            get { return bookingTime; }
            // No setter for read-only property
        }
        // A constructor that takes a Room and a Guest
        public Booking(Room room, Guest guest)
        {
            
            // Check if the room is already booked
            if (room.IsBooked)
            {
                Console.WriteLine("Room is already booked");
                bookedRoom = null; // Set to null or throw an exception if the booking cannot be created.
                bookingGuest = null;
            }
            else
            {
                bookedRoom = room;
                bookingGuest = guest;
                //BookingTime = DateTime.Now;
                Console.WriteLine($"Booking created for Room Number: {room.RoomNumber} and Guest National ID: {guest.National_ID}");
            }
        }

        /*A method ConfirmBooking() that: 
        ▪ Checks if the room is booked 
        ▪ If not, books the room and prints guest name and room number 
        */

        //public void ConfirmBooking()
        //{
        //    if (bookedRoom == null)
        //    {
        //        Console.WriteLine("Booking could not be confirmed because the room was already booked when the booking was initiated.");
        //        return;
        //    }

        //    // 1. Checks if the room is booked
        //    if (!bookedRoom.IsBooked)
        //    {
        //        // 2. If not, books the room and prints guest name and room number
        //        bookedRoom.Book();
        //        this.bookingTime = DateTime.Now; // 10. Sets the booking time to the current time (use DateTime.Now for current time including time)

        //        Console.WriteLine("Booking Time is : " + BookingTime);
        //        Console.WriteLine("Booking confirmed for " + bookingGuest.Name + " in room " + bookedRoom.RoomNumber);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Room " + bookedRoom.RoomNumber + " is already booked. Booking cannot be re-confirmed.");
        //    }

        //}
        
    }
}
