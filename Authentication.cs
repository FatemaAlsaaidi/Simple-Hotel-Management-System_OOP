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

        public static bool CheckAdmin(string AdminID, string password)
        {
            // Check if the provided AdminID matches the hardcoded admin ID
            if (AdminID == "12345")
            {
                return true; // Admin ID exists
            }
            return false; // Admin ID does not exist
        }


        // ============================ Ckeck if Password Exist ============================
        public static bool CheckPassword(string nationalID, string hashPassword)
        {
            Guest user = Guest.guest.FirstOrDefault(g => g.National_ID == nationalID);
            if (user != null)
            {
                return user.HashPassword == hashPassword;
            }
            return false;
        }





    }
}
