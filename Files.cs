﻿using System;
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

        // Function to load room data from a file
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


    }
}
