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

        // Function to save room data to a file
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


    }
}
