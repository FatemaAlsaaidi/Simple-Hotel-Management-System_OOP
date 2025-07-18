using System.Data;

namespace Simple_Hotel_Management_System_OOP
{
    internal class Program
    {
        // Flag if Login In Seccussfully
        public static bool isLogin = false; // Flag to check if the user is logged in

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear(); // Clear the console for a fresh start
                Console.WriteLine("Welcome to the Simple Hotel Management System!");
                // Option to book a room or cancel room 
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("0. Exit");
                char choice = Console.ReadKey().KeyChar;
                Console.ReadKey();
                switch (choice)
                {
                    case '1':
                        SignUp(); // Call the SignUp method to handle user registration
                        Console.WriteLine("User data saved successfully.");
                        Console.ReadLine(); // Wait for user input before continuing

                        break;
                    case '2':
                        //PrintData();
                        Console.ReadLine(); // Wait for user input before continuing
                        SignIn();
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case '0':
                        Console.WriteLine("Exiting the system. Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

       

        public static void SignUp()
        {
            // ============= Enter User Name ==============
            string name = EnterData.EnterUserName();
            if (name == "null")
            {
                Console.WriteLine("Invalid name. Please try again.");
                return; // Exit if the name is invalid
            }

            // ============= Enter User National ID ==============
            string NationalID = EnterData.EnterUserNationalID();
            if (NationalID == "null")
            {
                Console.WriteLine("Invalid National ID. Please try again.");
                return; // Exit if the National ID is invalid
            }
            else
            {
                // Check if the National ID already exists
                if (Authentication.CheckUserIDExist(NationalID))
                {
                    Console.WriteLine("National ID already exists. Please enter a different National ID.");
                    return; // Exit if the National ID already exists
                }
            }

            // ============= Enter User Phone Number ==============
            string PhoneNumber = EnterData.EnterUserPhoneNumber();
            if (PhoneNumber == "null")
            {
                Console.WriteLine("Invalid phone number. Please try again.");
                return; // Exit if the phone number is invalid
            }

            // ============= Enter User Password ==============
            string HashPassword = EnterData.EnterUserPassword();
            if (HashPassword == "null")
            {
                Console.WriteLine("Invalid password. Please try again.");
                return; // Exit if the password is invalid
            }
            else
            {   // Check if the password already exists
                if (Authentication.ExistPassword(HashPassword))
                {
                    Console.WriteLine("Password already exists. Please enter a different password.");
                    return; // Exit if the password already exists
                }
            }

            // ============ Enter User Address ==============
            string Address = EnterData.EnterUserAddress();
            if (Address == "null")
            {
                Console.WriteLine("Invalid address. Please try again.");
                return; // Exit if the address is invalid
            }

            // ============================ Save User Data ============================
            Guest newGuest = new Guest(name, NationalID, PhoneNumber, Guest.HotelName, HashPassword, Address);
            Guest.guest.Add(newGuest); // Add the new guest to the static list of guests
        }

        public static void SignIn()
        {
            // ============= Enter User National ID ==============
            string NationalID = EnterData.EnterUserNationalID();

            // check if NAtional ID value is exist 
            if (NationalID == "null")
            {
                Console.WriteLine("Nation ID can not be empty");
            } else {
                if (Authentication.CheckUserIDExist(NationalID) == true)
                {
                    string HashPassword = EnterData.EnterUserPassword();
                    if (HashPassword == "null")
                    {
                        Console.WriteLine("Password dose not be empty");
                    }
                    else
                    {
                        if (Authentication.ExistPassword(HashPassword) == true)
                        {
                            Console.WriteLine("Successfully Login");
                            isLogin = true;

                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Please try again.");
                            isLogin = false; // Set isLogin to false if the password is incorrect
                        }
                    }
                }
                else
                {
                    Console.WriteLine("National ID does not exist. Please sign up first.");
                    isLogin = false; // Set isLogin to false if the National ID does not exist
                }
            }
        }

        //public static void PrintData()
        //{
        //    // Print all registered guests
        //    foreach (Guest guest in Guest.guest)
        //    {
        //        Console.WriteLine($"Name: {guest.Name}, National ID: {guest.National_ID}, Phone Number: {guest.PhoneNumber}, Address: {guest.Address}");
        //    }
        //}

    }
}
