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
        private int BookingCounter = 0; // Counter to generate unique Booking IDs
        private int bookingID; // Unique identifier for the booking
        private Room bookedRoom; // The room that is booked
        private Guest bookingGuest; // The guest who booked the room
        private DateTime bookingTime; // The time when the booking was made
        public double TotalPrice { get; set; } // Number of nights for the booking
        // Properties for Booking
        public int BookingID
        {
            get { return BookingID; }
            // No setter for read-only property
        }
        public Room BookedRoom
        {
            get { return bookedRoom; }
            // No setter for read-only property
        }
        public Guest BookingGuest
        {
            get { return bookingGuest; }
            // No setter for read-only property
        }

        public DateTime BookingTime
        {
            get { return bookingTime; }
            // No setter for read-only property
        }
        // A constructor that takes a Room and a Guest
        public Booking(Room room, Guest guest, int Nights)
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
                bookingID = ++BookingCounter; // Increment the counter and assign a unique Booking ID
                bookedRoom.IsBooked = true; // Mark the room as booked
                TotalPrice = room.DailyRate * Nights; // Calculate total price based on nights and room price
                bookingTime = DateTime.Now; // Set the booking time to the current time
                Console.WriteLine($"Booking created for Room Number: {room.RoomNumber} and Guest National ID: {guest.National_ID}");

            }
        }

       
        
    }
}
