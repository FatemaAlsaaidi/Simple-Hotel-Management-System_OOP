using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Room
    {
        private int roomNumber ;
        private bool isBooked;

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
        public Room(int roomNumber, bool isBooked, string hotelName = "ABC Hotel")
        {
            this.roomNumber = roomNumber;
            this.isBooked = isBooked;
            HotelName = hotelName;
        }

        public Room()
        {
            // Default constructor initializes roomNumber to 10 and isBooked to false
            this.roomNumber = 1;
            this.isBooked = false;
            HotelName = "ABC Hotel"; // Default hotel name
        }





        }
}
