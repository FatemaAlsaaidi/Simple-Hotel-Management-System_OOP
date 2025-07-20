using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Hotel_Management_System_OOP
{
    // Class: Room
    // Purpose: Represents a hotel room with its booking status.
    class Room
    {

        public static List<Room> rooms = new List<Room>(); // Static list to hold all rooms
        // private fields for Room properties
        private int roomNumber ;
        private bool isBooked;
        private bool isCancel;
        public double DailyRate { get; set; } // Public property for room price, using auto-property syntax
        private static int roomCount = 100; // Static variable to keep track of the number of rooms
        public string roomType { get; set; } // Static field for room type, can be changed if needed

        // Add a static method GetRoomCount() that returns the count. (Missing)


        public int RoomNumber
        {
            get { return roomNumber; }
            set
            {
                if (value > 100) // Ensure room number is positive
                {
                    roomNumber = value;
                }
                else
                {
                    Console.WriteLine("Room number must be a positive integer.");
                }
            }
        }

        // property for IsBooked
        public bool IsBooked
        {
            get { return isBooked; }
            set
            {
                if (value)
                {
                    isBooked = true;
                }
                else
                {
                    isBooked = false;

                }
            }
        }

        public bool IsCancel
        {
            get { return isCancel; }
            set
            {
                if (value)
                {
                    isCancel = true;
                }
                else
                {
                    isCancel = false;
                }
            }
        }

        public Room()
        {
            // Default constructor initializes roomNumber to 10 and isBooked to false
            roomCount++;
            roomNumber = roomCount; // Assign a unique room number based on the count
            isBooked = false;
            DailyRate = 100.0; // Default daily rate for the room
            isCancel = false; // Initialize isCancel to false
            roomType = "Standard"; // Default room type

        }
        // Overloaded constructor to initialize room with specific values  // used it when load data from file 
        public Room(int roomNumber, string roomType, double dailyRate, bool isBooked) 
        {
            this.roomNumber = roomNumber; // Assign the room number
            this.roomType = roomType; // Assign the room type
            this.DailyRate = dailyRate; // Assign the daily rate
            this.isBooked = isBooked; // Set the booking status
            this.isCancel = false; // Initialize isCancel to false
        }

        // enter the daily rate for the room
        public static double Daily_Rate(int RoomNumber)
        {
            
            for (int i = 0; i < roomCount; i++)
            {
                if (rooms[i].RoomNumber == RoomNumber)
                {
                    Console.WriteLine($"Enter the daily rate for room {rooms[i].RoomNumber}:");
                    double dailyRate = 0.0; // Initialize daily rate variable
                    dailyRate = rooms[i].DailyRate; // Get the daily rate for the specified room
                    break;
                }
            }
            return rooms[RoomNumber].DailyRate; // Return the daily rate for the specified room
        }
        // =============================== Admin services ====================================
        // Add new rooms by admin 
        public static void AddRoom()
        {
            string addAnotherRoom = "N";
            do 
            { 
                Room newRoom = new Room(); // Create a new room with the specified daily rate
                rooms.Add(newRoom); // Add the new room to the list of rooms

                for (int i = 0; i < rooms.Count; i++)
                {
                    if (roomCount == rooms[i].RoomNumber)
                    {
                        Console.WriteLine("Current Daily Rate for Room " + rooms[i].RoomNumber + ": " + rooms[i].DailyRate);
                        Console.WriteLine("Do you want to more price to current daily rate? (y/n)");
                        if (Console.ReadLine().ToLower() == "y")
                        {

                            Console.WriteLine("Enter the new daily rate for Room " + rooms[i].RoomNumber + ":");
                            double newDailyRate;
                            while (!double.TryParse(Console.ReadLine(), out newDailyRate))
                            {
                                Console.WriteLine("Invalid input. Please enter a valid daily rate greater than current rate: " + rooms[i].DailyRate);
                            }
                            rooms[i].DailyRate += newDailyRate; // Update the daily rate for the room

                            Console.WriteLine("Room " + rooms[i].RoomNumber + " added successfully with daily rate: " + rooms[i].DailyRate);
                        }
                        else
                        {
                            Console.WriteLine("Daily rate remains unchanged.");
                        }
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("Do you want to add a room type? (y/n)");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            do
                            {
                                Console.WriteLine("Select the room type for new room " + rooms[i].RoomNumber + ":");
                                Console.WriteLine("1. Standard Room");
                                Console.WriteLine("2. Deluxe Room");
                                Console.WriteLine("3. Suite Room");
                                int roomTypeChoice;
                                while (!int.TryParse(Console.ReadLine(), out roomTypeChoice) || roomTypeChoice < 1 || roomTypeChoice > 3)
                                {
                                    Console.WriteLine("Invalid input. Please select a valid room type (1-3):");
                                }
                                switch (roomTypeChoice)
                                {
                                    case 1:
                                        rooms[i].roomType = "Standard Room";
                                        break;
                                    case 2:
                                        rooms[i].roomType = "Deluxe Room";
                                        break;
                                    case 3:
                                        rooms[i].roomType = "Suite Room";
                                        break;
                                    default:
                                        Console.WriteLine("Invalid room type selected.");
                                        break;
                                }
                            } while (rooms[i].roomType == null && Console.ReadLine().ToLower() == "y"); // Ensure room type is selected

                        }
                        else
                        {
                            rooms[i].roomType = "Standard Room"; // Default room type if not specified
                        }
                        Console.WriteLine("Room " + rooms[i].RoomNumber + " added successfully with type: " + rooms[i].roomType);
                        Files.SaveRoomDataToFile(rooms); // Save the room data to a file
                        Console.WriteLine("Room data saved to file successfully.");
                        Console.WriteLine("=======================================================");
                    } 
                    Console.WriteLine("Do you want to add another room? (y/n)");
                    addAnotherRoom = Console.ReadLine(); // Read user input for adding another room 
                    if (addAnotherRoom.ToLower() == "n")
                        {
                            break; // Exit the loop if the user does not want to add another room
                        }
                    }
                } while (addAnotherRoom.ToLower() == "y"); // Continue adding rooms until the user chooses not to
        }

        // Remove rooms by admin
        public static void RemoveRoom(int roomNumber)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomNumber == roomNumber)
                {
                    rooms[i].isCancel = true; // Remove the room from the list
                    Console.WriteLine("Room " + roomNumber + " removed successfully.");
                    return;
                }
            }
            Console.WriteLine("Room " + roomNumber + " not found.");
        }


        // View all rooms by admin
        public static void ViewAllRooms()
        {
            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms available.");
                return;
            }
            Console.WriteLine("List of all rooms:");
            foreach (Room room in rooms)
            {
                if (room.isCancel)
                {
                    continue; // Skip canceled rooms
                }
                Console.WriteLine($"Room Number: {room.RoomNumber}, Daily Rate: {room.DailyRate}, Is Booked: {room.IsBooked}");
            }
        }

        // view all canceled rooms 
        public static void ViewAllCancelRooms()
        {
            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms available.");
                return;
            }
            Console.WriteLine("List of all rooms:");
            foreach (Room room in rooms)
            {
                if (!room.isCancel)
                {
                    continue; // Skip canceled rooms
                }
                Console.WriteLine("Cancled Romms are: ");
                Console.WriteLine($"Room Number: {room.RoomNumber}, Daily Rate: {room.DailyRate}, Is Booked: {room.IsBooked}");
            }

        }
        // =================================== Guest services ====================================

        // Create a method called Book() that sets isBooked to true.

        public static int NumberOFNights()
        {
            Console.WriteLine("Enter the number of nights you want to book the room for:");
            int nights;
            while (!int.TryParse(Console.ReadLine(), out nights) || nights <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of nights greater than 0.");
            }
            Console.WriteLine($"You have selected to book the room for {nights} nights.");
            return nights; // Return the number of nights for booking
        }
        public static void BookRoom(int roomnumber)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomNumber == roomnumber)
                {
                    if (!rooms[i].isBooked)
                    {
                        if (rooms[i].isCancel)
                        {
                            Console.WriteLine("Room is canceled and cannot be booked.");
                            return;
                        }
                        else
                        {         
                            int nights = NumberOFNights(); // Get the number of nights for booking
                            Console.WriteLine("=======================================================");
                            Console.WriteLine($"You have booked Room {rooms[i].RoomNumber} for {nights} nights.");
                            Console.WriteLine($"Total Price: {rooms[i].DailyRate * nights}");
                            rooms[i].isBooked = true; // Set the room as booked

                            Console.ReadLine();
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Booking failed. Room is already booked.");
                    }
                }
            }

        }
        //Create a method called Free() that sets isBooked to false. 
        public static void CancelRoomBooking(int roomnumber)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomNumber == roomnumber)
                {
                    if (rooms[i].isBooked)
                    {
                        rooms[i].isBooked = false;
                        Console.WriteLine("Room booking canceled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Canceling failed. Room is already free.");
                    }
                }
            }
        }

        // Create a method called GetRoomDetails() that returns the room details as a string.
        public string GetRoomDetails(String RoomNumber)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (rooms[i].RoomNumber.ToString() == RoomNumber)
                {
                    return $"Room Number: {rooms[i].RoomNumber}, Daily Rate: {rooms[i].DailyRate}, Is Booked: {rooms[i].IsBooked}";
                }

            }

            if (rooms.Count == 0)
            {
                return "No rooms available.";
            }
            else
            {
                return "Room not found.";
            }
        }

        // Create a method called GetAvailableRooms() that returns a list of available rooms. this can through admin 
        public static List<Room> ViewBookedRooms()
        {

            List<Room> availableRooms = new List<Room>();
            foreach (Room room in rooms)
            {
                if (!room.IsBooked)
                {
                    availableRooms.Add(room);
                }
            }
            return availableRooms;
        }

        // Create a method called GetBookedRooms() that returns a list of booked rooms.
        public static void ViewAvailableRooms()
        {
            //List<Room> bookedRooms = new List<Room>();
            //foreach (Room room in rooms)
            //{
            //    if (room.IsBooked)
            //    {
            //        bookedRooms.Add(room);
            //    }
            //}
            //return bookedRooms;
            if (rooms.Count == 0)
            {
                Console.WriteLine("No rooms available.");
                return;
            }
            else
            {
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].isBooked == false && rooms[i].isCancel == false)
                    {
                        Console.WriteLine($"Room Number : {rooms[i].roomNumber}");
                        Console.WriteLine($"Daily Rate : {rooms[i].DailyRate}");
                        Console.WriteLine("======================================");
                    }
                }
            }
        }

        // create function to view booked rooms with specific guests with National Id
        public static void ViewBookedRoomsByGuest(string nationalId)
        {
            bool found = false;
            foreach (Booking booking in Booking.bookingHistory)
            {
                if (booking.bookingGuest.National_ID == nationalId)
                {
                    Console.WriteLine($"Booking ID: {booking.BookingID}, Room Number: {booking.bookedRoom.RoomNumber}, Guest Name: {booking.bookingGuest.Name}, Booking Time: {booking.BookingTime}, Total Price: {booking.TotalPrice}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No bookings found for the specified guest.");
            }
        }




















    }
}
