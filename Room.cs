using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    // Class: Room
    // Purpose: Represents a hotel room with its booking status.
    class Room
    {
        public static List<Room> rooms = new List<Room>(); // Static list to hold all rooms

        private int roomNumber ;
        private bool isBooked;
        public double DailyRate { get; set; } // Public property for room price, using auto-property syntax
        private static int roomCount = 100; // Static variable to keep track of the number of rooms

        // Add a static method GetRoomCount() that returns the count. (Missing)
       

        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                if (value > 100) // Ensure room number is positive
                {
                    roomNumber = value;
                }
                else
                {
                    Console.WriteLine("Room number must be a positive integer.");
                }
            }
        }

        // property for IsBooked
        public bool IsBooked
        {
            get { return isBooked; }
            set
            {
                if (value)
                {
                    isBooked = true;
                }
                else
                {
                    isBooked = false;

                }
            }
        }
        // Add constructor overloads to Room class to initialize data during object creation.
        public Room(bool isBooked, double daily_rate)
        {
            roomCount++; // Increment the room count for each new room created
            roomNumber = roomCount; // Assign the provided room number
            isBooked = isBooked;
            DailyRate = daily_rate; // Assign the daily rate for the room
        }

        public Room()
        {
            // Default constructor initializes roomNumber to 10 and isBooked to false
            roomCount++;
            roomNumber = roomCount; // Assign a unique room number based on the count
            isBooked = false;
        }

        // enter the daily rate for the room
        public static double Daily_Rate(int RoomNumber)
        {
            
            for (int i = 0; i < roomCount; i++)
            {
                if (rooms[i].RoomNumber == RoomNumber)
                {
                    Console.WriteLine($"Enter the daily rate for room {rooms[i].RoomNumber}:");
                    double dailyRate = 0.0; // Initialize daily rate variable
                    dailyRate = rooms[i].DailyRate; // Get the daily rate for the specified room
                    break;
                }
            }
            return rooms[RoomNumber].DailyRate; // Return the daily rate for the specified room
        }
        // =============================== Admin services ====================================
        // Add new rooms by admin 
        public static void AddRoom()
        {
            Room newRoom = new Room(); // Create a new room with the specified daily rate
            rooms.Add(newRoom); // Add the new room to the list of rooms
            for (int i = 0; i < rooms.Count; i++)
            {
                if (roomCount == rooms[i].RoomNumber)
                {
                    Console.WriteLine("Current Daily Rate for Room " + rooms[i].RoomNumber + ": " + rooms[i].DailyRate);
                    Console.WriteLine("Do you want to change the daily rate? (y/n)");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        Console.WriteLine("Enter the new daily rate for Room " + rooms[i].RoomNumber + ":");
                        double newDailyRate;
                        while (!double.TryParse(Console.ReadLine(), out newDailyRate) || newDailyRate < rooms[i].DailyRate)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid daily rate greater than current rate: " + rooms[i].DailyRate);
                        }
                        rooms[i].DailyRate = newDailyRate; // Update the daily rate for the room
                    }
                    else
                    {
                        Console.WriteLine("Daily rate remains unchanged.");
                    }
                }
            }

        }

       












    }
}
