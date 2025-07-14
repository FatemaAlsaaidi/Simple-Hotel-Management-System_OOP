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
        // private fields for Guest properties
        private string name;
        private string national_ID;
        private static string hotelName = "ABC Hotel"; // Static field for hotel name
        private static int guestCount = 0; // Static variable to keep track of the number of guests
        private static int guestNumber; // Static variable to assign a unique guest number
        private string password; // Private field for BookingTime
        public string Password
        {
            set { password = value; }
            // No setter for write-only property
        }

        // Auto-property for name 
        public string Name
        {
            get { return name; }
            set 
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length >= 3)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Guest name must not be empty and must be at least 3 characters long.");
                    
                }
            }
        }

        // Auto-property for national ID
        public string National_ID
        {
            get { return national_ID; }
            set 
            {
                // Requirement: Guest ID cannot be empty.
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 3) // You had Length == 3, if it's for validation based on requirement, keep it.
                {
                    national_ID = value;
                }
                else
                {
                    Console.WriteLine("National ID must not be empty and must be exactly 3 characters long."); // Updated message
                    // Similar to Name, consider throwing an exception or handling invalid state.
                }
            }

        }

        // Add constructor overloads to Guest class to initialize data during object creation.
        public Guest(string name, string national_ID, string hotelName, string password)
        {
            guestCount++; // Increment the guest count for each new guest created
            guestNumber = guestCount; // Assign a unique guest number based on the count
            Name = name;
            National_ID = national_ID;
            Guest.hotelName = hotelName; // Set the static hotel name
            Password = password;
        }
        public Guest()
        {
            guestCount++; // Increment the guest count for each new guest created
            guestNumber = guestCount; // Assign a unique guest number based on the count
            // Default constructor initializes name and national ID to empty strings
            Name = "Unknown";
            National_ID = "000";
            hotelName = "ABC Hotel"; // Default hotel name
            Password = "XXXX";
        }
    }
}
