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
        private static int roomCount = 0; // Static variable to keep track of the number of rooms

        // Add a static method GetRoomCount() that returns the count. (Missing)
       

        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                if (value > 0) // Ensure room number is positive
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

        // Create a method called Book() that sets isBooked to true.
        public void BookRoom()
        {
            if (!isBooked)
            {
                isBooked = true;
                Console.WriteLine("Room booked successfully.");
            }
            else
            {
                Console.WriteLine("Booking failed. Room is already booked.");
            }
        }

        //Create a method called Free() that sets isBooked to false. 
        public void CancelRoomBooking()
        {
            if (isBooked)
            {
                isBooked = false;
                Console.WriteLine("Room Cancel booked successfully.");
            }
            else
            {
                Console.WriteLine("Canceling failed. Room is already Canceled.");
            }
        }

        // Create a method called GetRoomDetails() that returns the room details as a string.
        public string GetRoomDetails(String RoomNumber)
        {
            for (int i = 0; i < roomCount; i++)
            {
                if (rooms[i].RoomNumber.ToString() == RoomNumber)
                {
                    return $"Room Number: {rooms[i].RoomNumber}, Daily Rate: {rooms[i].DailyRate}, Is Booked: {rooms[i].IsBooked}";
                }

            }

            if (rooms.Count == 0)
            {
                return "No rooms available.";
            }
            else
            {
                return "Room not found.";
            }
        }

        // Create a method called GetAvailableRooms() that returns a list of available rooms.







    }
}
