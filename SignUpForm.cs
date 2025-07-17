using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class SignUpForm
    {
        public static bool isValid = true; // Flag to check if every user input is valid
        public static bool isSaved = false; // Flag to check if user data is saved successfully

       
        // ================================= Enter User Name ===============================
        public static string EnterUserName()
        {

            try
            {
                string name = ""; // Initialize name variable
                do
                {
                    Console.Write("Enter your name: ");
                    name = Console.ReadLine();
                    //isValid = 

                    if (!Validation.IsValidString(name))
                    {
                        isValid = false; // Set isValid to false if the name is invalid
                    }
                    else
                    {
                        isValid = true; // Set isValid to true if the name is valid
                    }
                } while (isValid == false); // Ensure name is not null or whitespace

                if (isValid)
                {
                    return name;
                }
                else
                {
                    return "null"; // Return false if the name is invali
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your name: " + ex.Message);
                return "null"; // Return false if an exception occurs
            }
        }

      

        
    }
}
