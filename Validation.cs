using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Validation
    {


        // ==================================== Validates if the input is a valid string =====================================
        public static bool IsValidString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
        // ==================================== Valid if password is valid ===================================
        public static bool IsValidPassword(string password)
        {
            // Example validation: password must be at least 6 characters long
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 3;
        }

        // ===================================== Validates if the input is a valid National id =====================================
        public static bool IsValidNationalID(string nationalID)
        {
            return string.IsNullOrWhiteSpace(nationalID);
        }


        // ==================================== Validates if the input is a valid phone number =====================================
        public static bool IsValidPhoneNumber(string PhoneNumber)
        {
            // Example validation: phone number must be at least 10 digits long
            return !string.IsNullOrWhiteSpace(PhoneNumber) && PhoneNumber.Length >= 8 && PhoneNumber.All(char.IsDigit) && (PhoneNumber.StartsWith("9") || PhoneNumber.StartsWith("7"));

        }

    }
}
