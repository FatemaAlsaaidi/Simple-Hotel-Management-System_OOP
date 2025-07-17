using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    // Class: Guest
    // Purpose: Represents a hotel guest with their personal information.
    class Guest
    {
        // list if gusts 
        public static List<Guest> guest = new List<Guest>(); // Static list to hold all guests

        // private fields for Guest properties
        public string Name { get; set; } // Public property for name, using auto-property syntax
        public string National_ID { get; set; } // Public property for national ID, using auto-property syntax
        public string PhoneNumber { get; set; } // Not used in the original code, but can be added if needed
        public string Address { get; set; } // Public property for address, not used in the original code but can be added if needed
        public static string HotelName = "ABC Hotel"; // Static field for hotel name
        public static int GuestCount = 1; // Static variable to keep track of the number of guests
        public static int GuestNumber { get; private set; } // Static variable to assign a unique guest number
        private string Password; // Private field for password
        public string HashPassword { get; set; } // Private field for hashed password

        public string PASSWORD
        {
            set
            {
               if (Password != null)
                    Password = value;
                
            }
        }
        
        
        // Add constructor overloads to Guest class to initialize data during object creation.
        public Guest(string name, string national_ID, string phoneNumber ,string hotelName, string hashPassword, string address)
        {
            GuestCount++; // Increment the guest count for each new guest created
            GuestNumber = GuestCount; // Assign a unique guest number based on the count
            Name = name;
            National_ID = National_ID;
            phoneNumber = phoneNumber; // Assign phone number, if needed
            HotelName = hotelName; // Set the static hotel name
            HashPassword = hashPassword;
            Address = address; // Assign address, if needed
        }
        
    }
}
