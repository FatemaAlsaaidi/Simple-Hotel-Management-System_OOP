using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        
        public static void CheckIn(string National_ID)
        {
            // 1. Show available rooms
            bookingHistory.Clear();
            Console.WriteLine("Available Rooms:");
            if ((Room.ViewAvailableRooms()) == -1)
            {
                Console.WriteLine("There is no room available");
            }
            else
            {
                // 2. Let user select room number
                Console.Write("Enter the room number you want to book: ");
                int roomNumber = int.Parse(Console.ReadLine());
                if (!Room.IsRoomAvailable(roomNumber))
                {
                    Console.Write("Invalid room number. Please enter a valid room number: ");
                }
                else
                {
                    // 3.Save the guests detail in the guestBookingInfo list
                    for (int i = 0; i < Guest.guest.Count; i++)
                    {
                        if (Guest.guest[i].National_ID == National_ID)
                        {
                            guestBookingInfo.Add(Guest.guest[i]); // ✅ Adds the guest object directly
                            Console.WriteLine($"Guest {Guest.guest[i].Name} with ID {Guest.guest[i].National_ID} is booking a room.");
                        }
                    }
                    //4.  Enter dates of check-In and check-Out 
                    //Console.WriteLine("Enter the number of days you want to book the room for: ");
                    //int numberOfDays;
                    //while (!int.TryParse(Console.ReadLine(), out numberOfDays) || numberOfDays <= 0)
                    //{
                    //    Console.Write("Invalid number of days. Please enter a valid number: ");
                    //}
                    // 5. Set check-in and check-out dates
                    Console.WriteLine("Setting check-in and check-out dates...");
                    Console.WriteLine($"Check-in Date: "); // Display today's date as check-in date

                    DateTime checkInDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine($"Check-in Date: "); // Display today's date as check-in date
                    DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

                    // calculate the number of booking room days 
                    int NumberOfDays = checkOutDate.Day - checkInDate.Day;
                    Console.WriteLine(NumberOfDays);






                    // Assuming check-in date is today and check-out date is numberOfDays later



                    // 6. Mark room as unavailable
                    Room selectedRoom = Room.GetRoomDetails(roomNumber);
                    if (selectedRoom != null)
                    {
                        selectedRoom.IsBooked = true; // Mark the room as booked
                        Console.WriteLine($"Room {roomNumber} has been booked successfully.");
                        // 7. Add booking to bookings history list
                        Booking newBooking = new Booking(selectedRoom, Guest.guest.FirstOrDefault(g => g.National_ID == National_ID), NumberOfDays, checkInDate, checkOutDate, true);
                        bookingHistory.Add(newBooking); // Add the new booking to the booking history
                    }
                   
                }

               
            }
        }

        // Method to check out a guest
        public void CheckOut(string National_ID)
        {
            // 1. show all booked rooms for the guest
            Console.WriteLine("Booked Rooms for Guest:");
            foreach (var booking in bookingHistory)
            {
                if (booking.bookingGuest.National_ID == National_ID && booking.IsActive)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingID}, Room Number: {booking.bookedRoom.RoomNumber}, Check-In: {booking.CheckInDate}, Check-Out: {booking.CheckOutDate}");
                    Console.WriteLine($"Total Price: {booking.TotalPrice:C}");
                    Console.WriteLine("--------------------------------------------------");
                }
            }
            // 2. Ask user for room number or booking ID
            bool found = false;

            Console.WriteLine("Enter the room number:");
            if (!int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Console.WriteLine("Invalid room number input.");
                return;
            }
            for (int i = 0; i < bookingHistory.Count; i++)
            {
                if (bookingHistory[i].bookedRoom.RoomNumber == roomNumber
                    && bookingHistory[i].IsActive
                    && bookingHistory[i].bookingGuest.National_ID == National_ID)
                {
                    bookingHistory[i].IsActive = false;
                    bookingHistory[i].bookedRoom.IsBooked = false;
                    Console.WriteLine($"Booking with this room number{bookingHistory[i].bookedRoom.RoomNumber} has be successfully cancel");
                    found = true;
                    break;

                }
            }
            if (!found)
            {
                Console.WriteLine("No active booking found for this room number under your ID.");
            }

        }

    }
}
