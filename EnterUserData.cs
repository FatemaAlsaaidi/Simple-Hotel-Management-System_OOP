using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    class EnterUserData
    {
        static int tries = 0; // Counter for the number of attempts to enter a valid data
        public static bool isValid = true; // Flag to check if every user input is valid

        // ====================== Enter User Name ======================== 

        public static string EnterUserName()
        {
            bool isValid = true; // Flag to check if the user input is valid
            try
            {
                string name = ""; // Initialize name variable
                do
                {
                    Console.Write("Enter your name: ");
                    name = Console.ReadLine();
                    if (!Validation.IsValidString(name))
                    {
                        isValid = false; // Set isValid to false if the name is invalid
                        tries++; // Increment the number of attempts
                    }
                    else
                    {
                        isValid = true; // Set isValid to true if the name is valid
                    }
                } while (isValid == false && tries >= 3); // Ensure name is not null or whitespace
                if (tries >= 3)
                {
                    Console.WriteLine("You have exceeded the maximum number of attempts to enter a valid name.");
                    return "null"; // Return "null" if the user exceeds the maximum number of attempts
                }
                tries = 0; // Reset the number of attempts after entering a valid name
                return isValid ? name : "null"; // Return name or "null" based on validity
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your name: " + ex.Message);
                return "null"; // Return "null" if an exception occurs
            }
        }

        
        // ===================== Enter User National ID ====================
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
       
                        isValid = false; // Set isValid to false if the name is invalid
                        tries++; // Increment the number of attempts
                    }
                    else
                    {
                        isValid = true; // Set isValid to false if the name is invalid
                    }
            
                } while (isValid == false && tries >= 3); // Ensure name is not null or whitespace
                if (tries >= 3)
                {
                    Console.WriteLine("You have exceeded the maximum number of attempts to enter a valid National ID.");
                    return "null"; // Return "null" if the user exceeds the maximum number of attempts
                }
                tries = 0; // Reset the number of attempts after entering a valid National ID

                return NationalID;
                


            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your name: " + ex.Message);
                return "null"; // Return false if an exception occurs
            }

        }

        // ===================== Enter User Phone Number ===================
        public static string EnterUserPhoneNumber()
        {
            string phoneNumber =""; // Initialize phone number variable
            try
            {

                do
                {
                    Console.Write("Enter your phone number: ");

                    phoneNumber = Console.ReadLine();
                    if (!Validation.IsValidPhoneNumber(phoneNumber))
                    {
                        Console.WriteLine("Invalid phone number. Please enter a valid phone number.");
                        isValid = false;
                        tries++;
                    }
                    else
                    {
                        isValid = true; // Set isValid to true if the phone number is valid
                    }


                } while (isValid == false && tries >= 3);


                if (isValid)
                {
                    return phoneNumber;
                }
                else
                {
                    return "null"; // Return false if the phone number is invalid
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "null";
            }
        }

        //  ==================== Enter User Password =========================
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
                        isValid = true;
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

        // ======================= Enter User Address ==========================
        public static string EnterUserAddress()
        {
            try
            {
                string Address = ""; // Initialize name variable
                do
                {
                    Console.Write("Enter your Address: ");
                    Address = Console.ReadLine();
                    if (!Validation.IsValidString(Address))
                    {
                        isValid = false; // Set isValid to false if the name is invalid
                    }
                    else
                    {
                        isValid = true; // Set isValid to true if the name is valid
                    }
                } while (isValid == false); // Ensure name is not null or whitespace
                return isValid ? Address : "null"; // Return name or "null" based on validity
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while entering your address: " + ex.Message);
                return "null"; // Return "null" if an exception occurs
            }
        }

    }
}
