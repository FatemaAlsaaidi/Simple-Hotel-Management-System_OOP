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

        // =============================== Enter User National ID =============================

        public static string EnterUserNationalID()
        {
            try
            {
                string NationalID = ""; // Initialize name variable
                do
                {
                    Console.Write("Enter your National ID: ");
                    NationalID = Console.ReadLine();
                    //isValid = 

                    if (!Validation.IsValidNationalID(NationalID))
                    {
                        // check if the National ID is exist before
                        if (Authentication.CheckUserIDExist(NationalID) == true)
                        {
                            Console.WriteLine("National ID already exists. Please enter a different National ID.");
                            isValid = false; // Set isValid to false if the name is invalid
                        }
                        else
                        {
                            isValid = true; // Set isValid to false if the name is invalid
                        }

                    }
                    else
                    {
                        isValid = true; // Set isValid to true if the name is valid
                    }
                } while (isValid == false); // Ensure name is not null or whitespace

                if (isValid)
                {
                    return NationalID;
                }
                else
                {
                    return "null";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your name: " + ex.Message);
                return "null"; // Return false if an exception occurs
            }

        }

        // ============================= Enter User Password ===============================
        public static string EnterUserPassword()
        {

            try
            {
                string Password = ""; // Initialize name variable
                do
                {
                    Console.Write("Enter your password: ");
                    Password = ReadPassword();

                    //isValid = 

                    if (!Validation.IsValidPassword(Password))
                    {
                        isValid = false; // Set isValid to false if the name is invalid
                    }
                    else
                    {
                        string enteredHashed = HashPassword(Password);
                        if (Authentication.ExistPassword(enteredHashed) == true)
                        {
                            Console.WriteLine("Password already exists. Please enter a different password.");
                            isValid = false; // Set isValid to false if the password already exists
                        }
                        else
                        {
                            isValid = true;
                        }
                    }
                } while (isValid == false); // Ensure name is not null or whitespace

                if (isValid)
                {

                    return Password;
                }
                else
                {
                    return "null";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your name: " + ex.Message);
                return "null"; // Return false if an exception occurs
            }
        }
        // Read password from console without echoing characters
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        // Hash the password using SHA256
        static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }






    }
}
