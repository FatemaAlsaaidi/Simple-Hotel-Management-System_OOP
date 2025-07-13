using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Room
    {
        private int roomNumber = 10;
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
        
    }
}
