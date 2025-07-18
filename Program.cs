using System.Data;

namespace Simple_Hotel_Management_System_OOP
{
    internal class Program
    {
        // Flag if Login In Seccussfully
        public static bool isLogin = false; // Flag to check if the user is logged in

        // admin nation id 
        public static string AdminNationalID = "12345"; // Static variable for admin National ID
        public static string AdminPassword = "123"; // Static variable for admin password
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
                        SignIn(); // Call the SignIn method to handle user login
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
            string name = EnterUserData.EnterUserName();
            if (name == "null")
            {
                Console.WriteLine("Invalid name. Please try again.");
                return; // Exit if the name is invalid
            }

            // ============= Enter User National ID ==============
            string NationalID = EnterUserData.EnterUserNationalID();
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
            string PhoneNumber = EnterUserData.EnterUserPhoneNumber();
            if (PhoneNumber == "null")
            {
                Console.WriteLine("Invalid phone number. Please try again.");
                return; // Exit if the phone number is invalid
            }

            // ============= Enter User Password ==============
            string HashPassword = EnterUserData.EnterUserPassword();
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
            string Address = EnterUserData.EnterUserAddress();
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
            // declare variable which save the out put result of functions of get the national id and password 
            string NationalID = "";
            string HashPassword = "";

            // ============= Enter User National ID ==============
            NationalID = EnterUserData.EnterUserNationalID();


            // check if NAtional ID value is exist 
            if (NationalID == "null")
            {
                Console.WriteLine("Nation ID can not be empty");
            } 
            else 
            {
                if (Authentication.CheckUserIDExist(NationalID) == true)
                {
                    HashPassword = EnterUserData.EnterUserPassword();
                    if (HashPassword == "null")
                    {
                        Console.WriteLine("Password dose not be empty");
                    }
                    else
                    {
                        if (Authentication.ExistPassword(HashPassword) == true)
                        {
                            Console.WriteLine("Login successful! Welcome to the hotel management system.");
                            HotelServicesMenu(); // Call the HotelServicesMenu method to show hotel services
                            Console.ReadLine(); // Wait for user input before continuing



                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Please try again.");
                        }
                   
                    }
                }
                else if(Authentication.CheckAdmin(NationalID, HashPassword))
                {
                    Console.WriteLine("Admin login successful! Welcome to the admin panel.");
                    AdminServicesMenu(); // Call the AdminServicesMenu method to show admin services
                    Console.ReadLine(); // Wait for user input before continuing
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

        // =========================== Menue of Hstel Services ===========================
        public static void HotelServicesMenu()
        {
            Console.Clear(); // Clear the console for a fresh start
            Console.WriteLine("Welcome to the Hotel Services Menu!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Book a Room");
            Console.WriteLine("2. Cancel a Room Booking");
            Console.WriteLine("3. View Booked Rooms");
            Console.WriteLine("4. View Available Rooms");
            Console.WriteLine("0. Exit to Main Menu");

            char choice = Console.ReadKey().KeyChar;
            Console.ReadKey();

            switch (choice)
            {
                case '1':
                    // Call the method to book a room'
                    Console.WriteLine("Enter the room number you want to book:");
                    int roomNumber = int.Parse(Console.ReadLine());
                    Room.BookRoom(roomNumber);
                    Console.ReadLine(); // Wait for user input before continuing    
                    break;
                case '2':
                    // Call the method to cancel a room booking
                    Console.WriteLine("Enter the room number you want to book:");
                    int roomNumber1= int.Parse(Console.ReadLine());
                    Room.CancelRoomBooking(roomNumber1);
                    Console.ReadLine(); // Wait for user input before continuing
                    break;
                case '3':
                    // Call the method to view booked rooms
                    Room.ViewBookedRooms();
                    Console.ReadLine(); // Wait for user input before continuing
                    break;
                case '4':
                    // Call the method to view available rooms
                    Room.ViewAvailableRooms();
                    Console.ReadLine(); // Wait for user input before continuing
                    break;
                case '0':
                    Console.WriteLine("Exiting to Main Menu.");
                    return; // Exit to main menu
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }


        }

        // ========================== Menu of Admin Services ===========================
        public static void AdminServicesMenu()
        {
            Console.Clear(); // Clear the console for a fresh start
            Console.WriteLine("Welcome to the Admin Services Menu!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Add a Room");
            Console.WriteLine("2. Remove a Room");
            Console.WriteLine("3. View All Rooms");
            Console.WriteLine("0. Exit to Main Menu");
            char choice = Console.ReadKey().KeyChar;
            Console.ReadKey();
            switch (choice)
            {
                case '1':
                    // Call the method to add a room
                    Room.AddRoom();
                    Console.WriteLine("Room added successfully.");
                    Console.ReadLine(); // Wait for user input before continuing
                    break;
                case '2':
                    // Call the method to remove a room
                    Console.WriteLine("Enter the room number you want to remove:");
                    int roomNumber = int.Parse(Console.ReadLine());
                    Room.RemoveRoom(roomNumber);
                    Console.WriteLine("Room removed successfully.");
                    Console.ReadLine(); // Wait for user input before continuing
                    break;
                case '3':
                    // Call the method to view all rooms
                    Room.ViewAllRooms();
                    Console.ReadLine(); // Wait for user input before continuing

                    break;
                case '0':
                    Console.WriteLine("Exiting to Main Menu.");
                    return; // Exit to main menu
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    }
}
