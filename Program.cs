using System.Data;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Simple_Hotel_Management_System_OOP
{
    internal class Program
    {
        static Guest currentGuest = null;


        static void Main(string[] args)
        {
            // Load room data from file at the start of the program
            Files.LoadRoomDataFromFile();

            // Load guest data from file at the start of the program
            Files.LoadGuestDataFromFile();

            // Load booking data from file at the start of the program
            Files.LoadBookingHistoryFromFile();

            while (true)
            {
                Console.Clear(); // Clear the console for a fresh start
                Console.WriteLine("Welcome to the Simple Hotel Management System!");
                // Option to book a room or cancel room 
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Services");
                Console.WriteLine("0. Exit");
                char choice = Console.ReadKey().KeyChar;
                Console.ReadKey();
                switch (choice)
                {
                    case '1':
                        SignUp(); // Call the SignUp method to handle user registration
                        Console.ReadLine(); // Wait for user input before continuing

                        break;
                    case '2':
                        //PrintData();
                        SignIn(); // Call the SignIn method to handle user login
                        Console.ReadLine(); // Wait for user input before continuing  
                        break;

                    case '3':
                        if (currentGuest.IsLogin)
                        {
                            // If the user is logged in, show hotel services menu
                            HotelServicesMenu();
                        }
                        else
                        {
                            Console.WriteLine("You need to sign in first to access hotel services.");
                            Console.WriteLine("Sign In...");
                            Console.ReadLine(); // Wait for user input before continuing
                            SignIn(); // Call the SignIn method to handle user login
                            if (currentGuest.IsLogin)
                            {
                                HotelServicesMenu(); // Show hotel services menu if login is successful
                            }
                            else
                            {
                                Console.WriteLine("Login failed. Please try again.");
                            }
                        }
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
                return ; // Exit if the name is invalid
            }
            else
            {
                // ============= Enter User National ID ==============
                string NationalID = EnterUserData.EnterUserNationalID();
                if (NationalID == "null")
                {
                    return; // Exit if the National ID is invalid
                }
                else
                {
                    // Check if the National ID already exists
                    if (Authentication.CheckUserIDExist(NationalID))
                    {
                        return; // Exit if the National ID already exists
                    }
                    else
                    {
                        // ============= Enter User Phone Number ==============
                        string PhoneNumber = EnterUserData.EnterUserPhoneNumber();
                        if (PhoneNumber == "null")
                        {
                            return; // Exit if the phone number is invalid
                        }
                        else
                        {
                            // ============= Enter User Password ==============
                            string HashPassword = EnterUserData.EnterUserPassword();
                            if (HashPassword == "null")
                            {
                                return; // Exit if the password is invalid
                            }
                            else
                            {   // Check if the password already exists
                                if (Authentication.ExistPassword(HashPassword))
                                {
                                    return; // Exit if the password already exists
                                }
                                else
                                {
                                    // ============ Enter User Address ==============
                                    string Address = EnterUserData.EnterUserAddress();
                                    if (Address == "null")
                                    {
                                        return; // Exit if the address is invalid
                                    }
                                    else
                                    {
                                        // ============================ Save User Data ============================
                                        Guest newGuest = new Guest(name, NationalID, PhoneNumber, Guest.HotelName, HashPassword, Address);
                                        Guest.guest.Add(newGuest); // Add the new guest to the static list of guests
                                        currentGuest = newGuest;
                                        Console.WriteLine("Registration successful! Welcome to the hotel management system.");
                                        // ==================== Save Guest Data to File ============================
                                        Files.SaveGuestDataToFile(Guest.guest); // Save the updated guest list to the file
                                    }

                                }
                            }

                        }

                    }
                }

            }
               
        }

        // Flag to check if the user is logged in function 
        public static bool IsLogin (string NationalID, string  HashPassword, bool isLogin){
            Guest currentGuest = Guest.guest.FirstOrDefault(g => g.National_ID == NationalID && g.HashPassword == HashPassword);
            if (currentGuest != null)
            {
                currentGuest.IsLogin = isLogin; // Set IsLogin to true for the current guest

            }

            return currentGuest != null && currentGuest.IsLogin; // Return true if the guest is logged in, false otherwise
        }

        


        public static void SignIn()
        {
            // declare variable which save the out put result of functions 
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
                            IsLogin(NationalID, HashPassword , true);
                            currentGuest = Guest.guest.FirstOrDefault(g => g.National_ID == NationalID && g.HashPassword == HashPassword); // Get the current guest based on National ID and password
                            Console.ReadLine(); // Wait for user input before continuing
                            HotelServicesMenu(); // Call the HotelServicesMenu method to show hotel services
                            Console.ReadLine(); // Wait for user input before continuing



                        }
                        else
                        {
                            Console.WriteLine("Incorrect password. Please try again.");
                            Guest currentGuest = Guest.guest.FirstOrDefault(g => g.National_ID == NationalID);
                            IsLogin(NationalID, HashPassword, false);
                        }
                   
                    }
                }
                else if (Authentication.CheckAdmin(NationalID, EnterUserData.EnterUserPassword()))
                {
                    Console.WriteLine("Admin login successful! Welcome to the admin panel.");
                    Guest currentGuest = Guest.guest.FirstOrDefault(g => g.National_ID == NationalID);
                    IsLogin(NationalID, HashPassword, true);
                    Console.ReadLine();
                    AdminServicesMenu(); // Call the AdminServicesMenu method to show admin services
                    Console.ReadLine(); // Wait for user input before continuing
                }
                else
                {
                    Console.WriteLine("National ID does not exist. Please sign up first.");
                    Console.ReadLine(); // Wait for user input before continuing
                    SignUp(); // Call the SignUp method to handle user registration

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
            bool InHotelServicesMenu = true; // Flag to control the hotel services menu loop
            while (InHotelServicesMenu)
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
                        // check if there are rooms available for booking
                        if (Room.rooms.Count(r => !r.IsBooked && !r.IsCancel) == 0)
                        {
                            Console.WriteLine("No rooms available for booking at the moment.");
                            Console.ReadLine(); // Wait for user input before continuing
                            break;
                        }
                        Console.WriteLine("Enter the room number you want to book:");
                        if (int.TryParse(Console.ReadLine(), out int roomNumber))
                        {
                            Room roomToBook = Room.rooms.FirstOrDefault(r => r.RoomNumber == roomNumber && !r.IsBooked && !r.IsCancel);
                            if (roomToBook != null)
                            {
                                Console.WriteLine("Enter the number of nights you wish to book:");
                                if (int.TryParse(Console.ReadLine(), out int nights) && nights > 0)
                                {
                                    if (currentGuest != null)
                                    {
                                        Booking newBooking = new Booking(roomToBook, currentGuest, nights);
                                        Console.WriteLine($"Booking successful! Room {roomToBook.RoomNumber} booked for {nights} nights at a total price of {newBooking.TotalPrice:C}.");
                                        // Add the new booking to the booking history
                                        Booking.bookingHistory.Add(newBooking); // Add the new booking to the static list of bookings
                                        // Save the booking to the file
                                        Files.SaveBookingDataToFile(Booking.bookingHistory); // Save the updated booking history to the file
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error: No guest is currently logged in.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid number of nights.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Room not available for booking.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid room number.");
                        }
                        Console.ReadLine();
                        break;

                    case '2':
  
                        // Call the method to cancel a room booking
                        Console.WriteLine("Enter the room number you want to book:");
                        int roomNumber1 = int.Parse(Console.ReadLine());
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
                        InHotelServicesMenu = false;
                        break; // Exit to main menu
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }


        }

        // ========================== Menu of Admin Services ===========================
        public static void AdminServicesMenu()
        {
            bool InAdminMenu = true;
            while (InAdminMenu)
            {
                Console.Clear(); // Clear the console for a fresh start
                Console.WriteLine("Welcome to the Admin Services Menu!");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Add a Room");
                Console.WriteLine("2. Remove a Room");
                Console.WriteLine("3. View All Rooms");
                Console.WriteLine("4. View All Cancelled Rooms");
                Console.WriteLine("0. Exit to Main Menu");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Move to the next line after reading the key
                Console.ReadKey();
                switch (choice)
                {
                    case '1':
                        // Call the method to add a room
                        Room.AddRoom();
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
                    case '4':
                        Room.ViewAllCancelRooms();
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                    case '0':
                        InAdminMenu = false;
                        break; // Exit to main menu
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

    }
}
