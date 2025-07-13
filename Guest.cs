using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Guest
    {
        // private fields for Guest properties
        private string name;
        private string national_ID;
        private static string hotelName = "ABC Hotel"; // Static field for hotel name
        private static int guestCount = 0; // Static variable to keep track of the number of guests
        private static int guestNumber; // Static variable to assign a unique guest number


        // Auto-property for name 
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Auto-property for national ID
        public string National_ID
        {
            get { return national_ID; }
            set 
            {
                // Validate national ID format 
                if (value.Length == 3)
                {
                    national_ID = value;
                }
                else
                {
                    throw new ArgumentException("National ID must be 14 characters long.");
                }
            }

        }

        // Add constructor overloads to Guest class to initialize data during object creation.
        public Guest(string name, string national_ID, string hotelName)
        {
            guestCount++; // Increment the guest count for each new guest created
            guestNumber = guestCount; // Assign a unique guest number based on the count
            Name = name;
            National_ID = national_ID;
            Guest.hotelName = hotelName; // Set the static hotel name
        }
        public Guest()
        {
            guestCount++; // Increment the guest count for each new guest created
            guestNumber = guestCount; // Assign a unique guest number based on the count
            // Default constructor initializes name and national ID to empty strings
            Name = string.Empty;
            National_ID = string.Empty;
            hotelName = "ABC Hotel"; // Default hotel name
        }
    }
}
