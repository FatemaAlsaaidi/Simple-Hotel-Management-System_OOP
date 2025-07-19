using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Booking
    {
        // booking history
        public static List<Booking> bookingHistory = new List<Booking>(); // Static list to hold all bookings
        // Booking Fields
        private int BookingCounter = 0; // Counter to generate unique Booking IDs
        private int bookingID; // Unique identifier for the booking
        private Room bookedRoom; // The room that is booked
        private Guest bookingGuest; // The guest who booked the room
        private DateTime bookingTime; // The time when the booking was made
        public static double TotalPrice { get; set; } // Number of nights for the booking
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
        public Booking(Room room, Guest guest, int nights)
        {
            if (room.IsBooked)
            {
                Console.WriteLine("Room is already booked.");
            }
            else
            {
                bookedRoom = room;
                bookingGuest = guest;
                bookingID = ++BookingCounter;
                bookedRoom.IsBooked = true;
                TotalPrice = room.DailyRate * nights;
                bookingTime = DateTime.Now;
                bookingHistory.Add(this);

                Console.WriteLine($"Booking confirmed for {guest.Name} in Room {room.RoomNumber}.");
                Console.WriteLine($"Total price: {TotalPrice:C} for {nights} nights.");
            }
        }


        



    }
}
