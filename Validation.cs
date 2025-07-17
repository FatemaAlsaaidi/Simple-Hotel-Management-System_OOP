using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Validation
    {

        // Validates if the input is a valid string 
        public static bool IsValidString(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length >= 3;
        }

        
    }
}
