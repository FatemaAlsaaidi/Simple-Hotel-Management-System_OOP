using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Files
    {
        // Create file to save room data
        public static string RoomFilePath = "rooms.txt"; // File path for room data
        // Create file to save guest data
        public static string GuestFilePath = "guests.txt"; // File path for guest data
        // Create file to save booking data
        public static string BookingFilePath = "bookings.txt"; // File path for booking data

        // ============================================ Room File Operations ============================================
        public static void SaveRoomDataToFile(List<Room> rooms)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(RoomFilePath))
            {
                foreach (Room room in rooms)
                {
                    file.WriteLine($"{room.RoomNumber},{room.roomType},{room.DailyRate},{room.IsBooked}");
                }
            }
        }
        public static void LoadRoomDataFromFile()
        {
            // clear list of room before loading data from file
            Room.rooms.Clear();
            // Check if the file exists before reading
            if (System.IO.File.Exists(RoomFilePath))
            {
                string[] lines = System.IO.File.ReadAllLines(RoomFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        int roomNumber = int.Parse(parts[0]);
                        string roomType = parts[1];
                        double dailyRate = double.Parse(parts[2]);
                        bool isBooked = bool.Parse(parts[3]);
                        // 1. Create a new Room object using the overloaded constructor
                        Room loadedRoom = new Room(roomNumber, roomType, dailyRate, isBooked);
                        // 2. Add this new Room object to the list
                        Room.rooms.Add(loadedRoom);
                    }
                }
            }
        }

        // ============================================ Guest File Operations ============================================
        public static void SaveGuestDataToFile(List<Guest> guests)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(GuestFilePath))
            {
                foreach (Guest guest in guests)
                {
                    file.WriteLine($"{guest.Name},{guest.National_ID},{guest.PhoneNumber}, {guest.Address}, {guest.HashPassword}");
                }
            }
        }
        public static void LoadGuestDataFromFile()
        {
            // clear list of guest before loading data from file
            Guest.guest.Clear();
            // Check if the file exists before reading
            if (System.IO.File.Exists(GuestFilePath))
            {
                string[] lines = System.IO.File.ReadAllLines(GuestFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        string name = parts[0];
                        string nationalID = parts[1];
                        string phoneNumber = parts[2];
                        string address = parts[3];
                        string hashPassword = parts[4];
                        // 1. Create a new Guest object using the overloaded constructor
                        Guest loadedGuest = new Guest(name, nationalID, phoneNumber, Guest.HotelName, hashPassword, address);
                        // 2. Add this new Guest object to the list
                        Guest.guest.Add(loadedGuest);

                    }
                }
            }
        }

        // ============================================ Booking File Operations ============================================
        public static void SaveBookingDataToFile(List<Booking> bookings)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(BookingFilePath))
            {
                foreach (Booking booking in bookings)
                {
                    file.WriteLine($"{booking.BookingID},{booking.bookedRoom},{booking.bookingGuest},{booking.BookingTime},{booking.TotalPrice}, {booking.CheckInDate}, {booking.CheckOutDate}, {booking.IsActive}");
                }
            }
        }

        public static void LoadBookingHistoryFromFile()
        {
            // clear list of BookingHistory before loading data from file
            Booking.bookingHistory.Clear();

            // check file exists before reading 
            if (System.IO.File.Exists(BookingFilePath))
            {
                // declare string array to hold lines from the file
                string[] lines = System.IO.File.ReadAllLines(BookingFilePath);
                foreach (string line in lines)
                {
                    // split the line by comma to get individual parts
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        // store every part of data in a variable
                        int bookingID = int.Parse(parts[0]);
                        Room bookedRoom = Room.rooms.FirstOrDefault(r => r.RoomNumber == int.Parse(parts[1]));
                        Guest bookingGuest = Guest.guest.FirstOrDefault(g => g.National_ID == parts[2]);
                        DateTime bookingTime = DateTime.Parse(parts[3]);
                        double totalPrice = double.Parse(parts[4]);
                        DateTime checkInDate = DateTime.Parse(parts[5]);
                        DateTime checkOutDate = DateTime.Parse(parts[6]);
                        bool isActive = bool.Parse(parts[7]);
                        // 1. Create a new Booking object using the constructor
                        Booking loadedBooking = new Booking(bookedRoom, bookingGuest, totalPrice,checkInDate, checkOutDate, isActive);

                        // 2. Set the properties of the loadedBooking object
                        loadedBooking.TotalPrice = totalPrice;
                        loadedBooking.BookingID = bookingID;
                        loadedBooking.BookingTime = bookingTime;
                        // 3. Add this new Booking object to the list
                        Booking.bookingHistory.Add(loadedBooking);


                    }

                }


            }
            else
            {
                Console.WriteLine("File dose not exist");
            }

        }


    }
}
