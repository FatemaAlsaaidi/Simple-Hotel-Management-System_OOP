using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class Authentication
    {
        // ============================ Ckeck if ID Exist ============================

        public static bool CheckUserIDExist(string UserID)
        {

            //Loop through the list of registered National IDs in guest oblect 
            foreach (Guest guest in Guest.guest)
            {
                // Check if the current guest's National ID matches the provided UserID
                if (guest.National_ID == UserID)
                {
                    return true; // User ID exists in the list
                }
            }

            return false; // User ID does not exist in the list

        }

        // ============================ Ckeck if Password Exist ============================
        public static bool ExistPassword(string HashPassword)
        {
            // Loop through the list of registered password
            foreach (Guest guest in Guest.guest)
            {
                // Check if the current guest's National ID matches the provided UserID
                if (guest.HashPassword.Equals(HashPassword, StringComparison.OrdinalIgnoreCase))
                {
                    return true; // User ID exists in the list
                }
            }
            return false; // User password does not exist in the list
        }



    }
}
