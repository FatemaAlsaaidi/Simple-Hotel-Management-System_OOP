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
            Console.WriteLine("========== Wellcome To Hostel System =======================");
            Console.ReadLine();
            // Load room data from file at the start of the program
            Files.LoadRoomDataFromFile();

            // Load guest data from file at the start of the program
            Files.LoadGuestDataFromFile(); 

            // Load booking data from file at the start of the program
            Files.LoadBookingHistoryFromFile();
            bool UsersSystemMenu = true;

            while (UsersSystemMenu)
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
                        // Check if a guest is currently logged in.
                        // Assuming 'currentGuest' is a static field in your Program class
                        if (Program.currentGuest == null || !Program.currentGuest.IsLogin) // Check if currentGuest is null OR not logged in
                        {
                            Console.WriteLine("You need to sign in first to access hotel services.");
                            Console.WriteLine("Signing In...");

                            // Call the SignIn method to handle user login.
                            // The SignIn method should ideally update Program.currentGuest upon successful login.
                            SignIn();

                            // After SignIn, check if a guest is now logged in.
                            if (Program.currentGuest != null && Program.currentGuest.IsLogin)
                            {
                                Console.WriteLine("Login successful! Redirecting to hotel services.");
                                HotelServicesMenu(currentGuest.National_ID, currentGuest.IsLogin); // Show hotel services menu if login is successful
                            }
                            else
                            {
                                Console.WriteLine("Login failed. Please try again or create an account.");
                            }
                        }
                        else // currentGuest is not null and is already logged in
                        {
                            Console.WriteLine($"Welcome back, {Program.currentGuest.Name}! Accessing hotel services...");
                            HotelServicesMenu(currentGuest.National_ID, currentGuest.IsLogin); // User is already logged in, show hotel services menu
                        }
                        // This ReadLine can be useful to pause the console after the entire process,
                        // but consider if it's truly needed after HotelServicesMenu() is called.
                        // If HotelServicesMenu() itself handles pausing or returns to a main menu,
                        // this ReadLine might be redundant or disruptive.
                        Console.ReadLine();
                        break;

                    case '0':
                        UsersSystemMenu = false; // Exit the main menu loop
                        break; // Exit the program
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
                    Console.WriteLine("National ID can not be empty"); // Notify user if National ID is invalid
                    return; // Exit if the National ID is invalid
                }
                else
                {
                    // Check if the National ID already exists
                    if (Authentication.CheckUserIDExist(NationalID))
                    {
                        Console.WriteLine("National ID already exists. Please try again with a different National ID.");
                        return; // Exit if the National ID already exists
                    }
                    else
                    {
                        // ============= Enter User Phone Number ==============
                        string PhoneNumber = EnterUserData.EnterUserPhoneNumber();
                        if (PhoneNumber == "null")
                        {
                            Console.WriteLine("Phone number can not be empty"); // Notify user if phone number is invalid
                            return; // Exit if the phone number is invalid
                        }
                        else
                        {
                            // ============= Enter User Password ==============
                            string HashPassword = EnterUserData.EnterUserPassword();
                            if (HashPassword == "null")
                            {
                                Console.WriteLine("Password can not be empty"); // Notify user if password is invalid
                                return; // Exit if the password is invalid
                            }
                            else
                            {   // Check if the password already exists
                                if (Authentication.ExistPassword(HashPassword))
                                {
                                    Console.WriteLine("Password already exists. Please try again with a different password.");
                                    return; // Exit if the password already exists
                                }
                                else
                                {
                                    // ============ Enter User Address ==============
                                    string Address = EnterUserData.EnterUserAddress();
                                    if (Address == "null")
                                    {
                                        Console.WriteLine("Address can not be empty"); // Notify user if address is invalid
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

        //// Flag to check if the user is logged in function 
        //public static bool IsLogin (string NationalID,  bool isLogin){
        //    Guest currentGuest = Guest.guest.FirstOrDefault(g => g.National_ID == NationalID && g.HashPassword == HashPassword);
        //    if (currentGuest != null)
        //    {
        //        currentGuest.IsLogin = isLogin; // Set IsLogin to true for the current guest

        //    }

        //    return currentGuest != null && currentGuest.IsLogin; // Return true if the guest is logged in, false otherwise
        //}

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
                        Console.WriteLine("Login successful! Welcome to the hotel management system.");
                        //currentGuest = Guest.guest.FirstOrDefault(g => g.National_ID == NationalID && g.HashPassword == HashPassword); // Problem: Should be Program.currentGuest
                        Console.ReadLine(); // Wait for user input before continuing
                                            // Check if a guest is currently logged in
                        for (int i = 0; i < Guest.guest.Count; i++)
                        {
                            if (Guest.guest[i].National_ID == NationalID)
                            {
                                currentGuest = Guest.guest[i]; // Assign the current guest based on National ID
                                if (currentGuest.IsLogin == false)
                                {
                                    // Set the IsLogin property to false
                                    currentGuest.IsLogin = true;
                                    Console.WriteLine("Login successful! Welcome to the hotel management system.");
                                    HotelServicesMenu(NationalID, currentGuest.IsLogin); // Directly calls menu, which is often not ideal for a login function
                                    Console.ReadLine(); // Wait for user input before continuing

                                }

                            }
                        }

                        
                    }
                }
                else if (Authentication.CheckAdmin(NationalID, EnterUserData.EnterUserPassword()))
                {
                    Console.WriteLine("Admin login successful! Welcome to the admin panel.");
                    Guest currentGuest = Guest.guest.FirstOrDefault(g => g.National_ID == NationalID); // Get the current guest based on National ID
                    //IsLogin(NationalID, HashPassword, true);
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

        public static void SignOut(string NationalID, bool IsLogin)
        {
            // Check if a guest is currently logged in
            for (int i = 0; i < Guest.guest.Count; i++)
            {
                if (Guest.guest[i].National_ID == NationalID)
                {
                    currentGuest = Guest.guest[i]; // Assign the current guest based on National ID
                    IsLogin = currentGuest.IsLogin; // Get the login status of the current guest
                    if (IsLogin == true)
                    {
                        // Set the IsLogin property to false
                        currentGuest.IsLogin = false;
                        Console.WriteLine($"Goodbye, {currentGuest.Name}! You have been successfully signed out.");
                        currentGuest = null; // Clear the current guest
                    }
                    else
                    {
                        Console.WriteLine("No guest is currently logged in.");
                    }
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
        public static void HotelServicesMenu(string national_ID, bool IsLogin)
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
                Console.WriteLine("0. Sign Out");

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
                        bool hasBooking = false;
                        Booking foundBooking = null; // to keep the booking reference if found

                        foreach (var booking in Booking.bookingHistory)
                        {
                            if (booking.bookingGuest.National_ID == national_ID)
                            {
                                hasBooking = true;
                                foundBooking = booking;
                                break;
                            }
                        }

                        if (hasBooking)
                        {
                            Console.WriteLine($"Guest with National ID {currentGuest.National_ID} has a booking for Room {foundBooking.bookedRoom.RoomNumber}.");

                            // Proceed to cancel or other actions:
                            Room.CancelRoomBooking(foundBooking.bookedRoom.RoomNumber);
                            Console.WriteLine("Booking cancelled successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No booking found for this guest.");
                        }

                        Console.ReadLine();
                        break;
                    case '3':
                        // Call the method to view booked rooms
                        //string NationalID = currentGuest.National_ID; // Get the current guest's National ID
                        Room.ViewBookedRoomsByGuest(national_ID);
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                    case '4':
                        // Call the method to view available rooms
                        Room.ViewAvailableRooms();
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                    case '0':
                        SignOut(national_ID, IsLogin); // Call the SignOut method to handle user logout
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
                Console.WriteLine("5. View All Booked Rooms");
                Console.WriteLine("6. View Booked Rooms By Guest");
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
                    case '5':
                        // Call the method to view all booked rooms
                        Room.ViewBookedRooms();
                        Console.ReadLine(); // Wait for user input before continuing
                        break;
                    case '6':
                        // Call the method to view booked rooms by guest
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
                                string nationalID = Console.ReadLine();
                                Room.ViewBookedRoomsByGuest(nationalID);
                                Console.ReadLine(); // Wait for user input before continuing
                            }
                            else
                            {
                                Console.WriteLine("National ID does not exist. Please try again.");
                                Console.ReadLine(); // Wait for user input before continuing
                            }
                        }
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
