namespace Simple_Hotel_Management_System_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Simple Hotel Management System!");
            // Option to book a room or cancel room 
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Book a room");
            Console.WriteLine("2. Cancel a room booking");
            Console.WriteLine("0. Exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) 
            {
                case 1:
                    // create new guest object
                    Guest guest = new Guest();
                    // =================================== Enter the name of guest ========================
                    try
                    {
                        do
                        {
                            Console.Write("Enter guest name: ");
                            guest.Name = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(guest.Name))
                            {
                                throw new ArgumentException("Guest name must be not null");
                            }
                        } while (string.IsNullOrWhiteSpace(guest.Name)); // Ensure name is not empty or whitespace
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return; // Exit if the name is invalid
                    }
                    // ========================== Enter the national ID of guest ==========================

                    
                    try
                    {
                        do
                        {
                            Console.Write("Enter guest national ID (3 characters): ");
                            guest.National_ID = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(guest.National_ID) || guest.National_ID.Length != 3)
                            {
                                throw new ArgumentException("National ID must be not null and be exactly 3 characters long.");
                            }
                        } while (string.IsNullOrWhiteSpace(guest.National_ID) || guest.National_ID.Length != 3); // Ensure national ID is not empty and exactly 3 characters long
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return; // Exit if the national ID is invalid
                    }
                    // Display room status
                    Room room = new Room();

                    Console.WriteLine($"Room before booking : {room.IsBooked}");
                    Booking booking = new Booking(room, guest); // Create a booking for the room and guest
                    // Book the room
                    booking.ConfirmBooking(); // Confirm the booking
                    //Console.WriteLine($"Guest {guest.Name} with National ID {guest.National_ID} is ready to book a room.");
                    Console.WriteLine($"Room after booking : {room.IsBooked}");


                    break;
                case 2:
                    Room cancelRoom = new Room();
                    cancelRoom.Book(); // Book the room first
                    Console.WriteLine($"Room before cancellation: {cancelRoom.IsBooked}");
                    cancelRoom.Free();
                    Console.WriteLine($"Room after cancellation: {cancelRoom.IsBooked}");

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
}
