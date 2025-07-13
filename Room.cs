using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Room
    {
        private int roomNumber ;
        private bool isBooked;
        private static int roomCount = 0; // Static variable to keep track of the number of rooms

        static string HotelName;
        // read-only property for RoomNumber

       

        public int RoomNumber
        {
            get { return roomNumber; }
            
        }

        // property for IsBooked
        public bool IsBooked
        {
            get { return isBooked; }

        }
        // Create a method called Book() that sets isBooked to true.
        public void Book()
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
        public void Free()
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

        // Add constructor overloads to Room class to initialize data during object creation.
        public Room(bool isBooked, string hotelName = "ABC Hotel")
        {
            roomCount++; // Increment the room count for each new room created
            this.roomNumber = roomCount; // Assign the provided room number
            this.isBooked = isBooked;
            HotelName = hotelName;
        }

        public Room()
        {
            // Default constructor initializes roomNumber to 10 and isBooked to false
            roomCount++;
            this.roomNumber = roomCount; // Assign a unique room number based on the count
            this.isBooked = true;
            HotelName = "ABC Hotel"; // Default hotel name
        }





        }
}
