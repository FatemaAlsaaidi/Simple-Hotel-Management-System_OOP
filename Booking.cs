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
        // guest booking list
        public static List<Guest> guestBookingInfo = new List<Guest>(); // Static list to hold all guests who have made bookings
        // Booking Fields
        private int BookingCounter = 0; // Counter to generate unique Booking IDs
        private int bookingID; // Unique identifier for the booking
        public Room bookedRoom; // The room that is booked
        public Guest bookingGuest; // The guest who booked the room
        private DateTime bookingTime; // The time when the booking was made
        private DateTime checkInDate; // The date when the guest checks in
        private DateTime checkOutDate; // The date when the guest checks out
        private bool isActive; // Indicates if the booking is currently active
        public double TotalPrice { get; set; } // Number of nights for the booking
        // Properties for Booking
        public int BookingID
        {
            get { return BookingID; }

            set { BookingID = value; }
        }
        //public Room BookedRoom
        //{
        //    get { return bookedRoom; }

        //    // No setter for read-only property
        //}
        

        public DateTime BookingTime
        {
            get { return bookingTime; }
            set { bookingTime = value; }
        }
        // property for CheckInDate
        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }

        }
        // property for CheckOutDate
        public DateTime CheckOutDate
        {
            get { return checkOutDate; }
            set
            {
                if (value < checkInDate)
                {
                    Console.WriteLine("Check-out date cannot be earlier than check-in date.");
                }
                else
                {
                    checkOutDate = value; // Set the check-out date if it's valid
                }
            }
        }

        // property for IsActive
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        // A constructor that takes a Room and a Guest
        public Booking(Room room, Guest guest, int nights, DateTime Check_Date_IN, DateTime check_Date_Out, bool Is_Active)
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
                CheckInDate = DateTime.Now;
                CheckOutDate = DateTime.Now.AddDays(nights);
                IsActive = true;
                bookingHistory.Add(this);

            }
        }
        // Create a method to check in a guest
        public void CheckIn(string National_ID)
        {
            // 1. Show available rooms
            bookingHistory.Clear();
            Console.WriteLine("Available Rooms:");
            Room.ViewAvailableRooms();

            // 2. Let user select room number
            Console.Write("Enter the room number you want to book: ");
            int roomNumber;
            while (!int.TryParse(Console.ReadLine(), out roomNumber) || !Room.IsRoomAvailable(roomNumber))
            {
                Console.Write("Invalid room number. Please enter a valid room number: ");
            }

            // 3.Save the guests detail in the guestBookingInfo list
            for (int i = 0; i < Guest.guest.Count; i++)
            {
                if (Guest.guest[i].National_ID == National_ID)
                {
                    guestBookingInfo.Add(Guest.guest[i]); // ✅ Adds the guest object directly
                    return;
                }
            }
            // 4. Enter number of days
            Console.WriteLine("Enter the number of days you want to book the room for: ");
            int numberOfDays;
            while (!int.TryParse(Console.ReadLine(), out numberOfDays) || numberOfDays <= 0)
            {
                Console.Write("Invalid number of days. Please enter a valid number: ");
            }
            // 5. Set check-in and check-out dates
            DateTime checkInDate = DateTime.Now;
            DateTime checkOutDate = checkInDate.AddDays(numberOfDays);
          






        }






    }
}
