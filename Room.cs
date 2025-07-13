using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Room
    {
        private int roomNumber=10 ;
        private bool isBooked = false;

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




    }
}
