namespace Simple_Hotel_Management_System_OOP
{
    internal class Program
    {
       
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
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SignUp();
                        Console.ReadLine(); // Wait for user input before continuing

                        break;
                    case 2:
                        Console.WriteLine("Sign In functionality is not implemented yet.");
                        Console.ReadLine(); // Wait for user input before continuing
                        break;

                    case 0:
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
            bool IsSaved = true; // Flag to check if the user is saved successfully

            SignUpForm SignUpForm = new SignUpForm(); // Create an instance of the SignUpForm class
                                                      // 
            // ======================== Enter Name ==========================
            string Name = SignUpForm.EnterUserName(); // Call the method to enter user name
            if (Name != "null")
            {
                Console.WriteLine("User name entered successfully.");
                IsSaved = true; // Set IsSaved to true if the name is valid
            }
            else
            {
                Console.WriteLine("Failed to enter user name.");
                IsSaved = false; // Set IsSaved to false if the name is invalid
                return;
            }


            // =================== Enter National ID ======================
            string NationalID = SignUpForm.EnterUserNationalID(); // Call the method to enter user National ID
            if (NationalID != "null")
            {
               
                Console.WriteLine("User National ID entered successfully.");
                IsSaved = true; // Set IsSaved to true if the National ID is valid

                
            }
            else
            {
                Console.WriteLine("Failed to enter user National ID.");
                IsSaved = false; // Set IsSaved to false if the National ID is invalid
                return;

            }

            // =================== Enter Phone Number ======================
            string PhoneNumber = SignUpForm.EnterUserPhoneNumber(); // Call the method to enter user Phone Number
            if (PhoneNumber != "null")
            {
                Console.WriteLine("User Phone Number entered successfully.");
                IsSaved = true; // Set IsSaved to true if the phone number is valid
            }
            else
            {
                Console.WriteLine("Failed to enter user Phone Number.");
                IsSaved = false; // Set IsSaved to false if the phone number is invalid
                return;
            }

            // =================== Enter Password ======================
            string HashPassword = SignUpForm.EnterUserPassword(); // Call the method to enter user Password
            if (HashPassword != "null")
            {
                Console.WriteLine("User Password entered successfully.");
                IsSaved = true; // Set IsSaved to true if the password is valid
            }
            else
            {
                Console.WriteLine("Failed to enter user Password.");
                IsSaved = false; // Set IsSaved to false if the password is invalid
                return;

            }

            // =================== Enter address ====================== 
            string Address = SignUpForm.EnterUserAddress(); // Call the method to enter user Address
            if (Address != "null")
            {
                Console.WriteLine("User Address entered successfully.");
                IsSaved = true; // Set IsSaved to true if the address is valid
            }
            else
            {
                Console.WriteLine("Failed to enter user Address.");
                IsSaved = false; // Set IsSaved to false if the address is invalid
                return;
            }

            // =========================== Save User Data ==============================
           
            if (IsSaved)
            {
                Guest newGuest = new Guest(Name, NationalID, PhoneNumber, Guest.HotelName, HashPassword, Address);
                Guest.guest.Add(newGuest); // Add the new guest to the static list of guests
                Console.WriteLine("User data saved successfully.");
            }
            else
            {
                Console.WriteLine("Failed to save user data. Please ensure all fields are valid.");
            }
              

            

        }


    }
}
