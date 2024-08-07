using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using SWAD_Team4_assignment_2;

namespace SWAD_Team4_assignment_2
{
    class Program
    {
        static List<Car> cars = new List<Car>();
        static List<CarRenter> carRenters = new List<CarRenter>();
        static List<CarOwner> carOwners = new List<CarOwner>();
        static List<AvailabilitySchedule> availabilitySchedules = new List<AvailabilitySchedule>();
        static List<Booking> bookings = new List<Booking>();
        static List<CarRenter> renters = new List<CarRenter>();
        static List<ICarStation> locations = new List<ICarStation>();
        static int nextCarId = 1; // Static counter for car IDs

        static void Main()
        {
            cars.Add(new Car("1", "Model S", "Tesla", 2022, 15000, "Red", true, "ABC123", 100));
            cars.Add(new Car("2", "Mustang", "Ford", 2021, 20000, "Blue", true, "XYZ789", 80));
            DateTime bday = new DateTime(2024, 8, 16);
            carRenters.Add(new CarRenter("Pofrz", "password", "001", 84048488, "user2@example.com", 0, bday, false, "licenseid", true));
            carRenters.Add(new CarRenter("KK47", "password", "002", 84048488, "user2@example.com", 0, bday, false, "licenseid", true));
            locations.Add(new ICarStation("01", "21 choo street"));
            locations.Add(new ICarStation("02", "47 primo street"));
            // Log In / Create User
            while (true)
            {
                Console.WriteLine("Welcome to iCar Car Rental System");
                Console.WriteLine("1. Log In");
                Console.WriteLine("2. Create Account");
                Console.WriteLine("3. Exit");
                Console.Write("\nPlease select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LogIn();
                        break;
                    case "2":
                        CreateAccount();
                        Console.Write("Do you wish to Log In? (Y/N): ");
                        string logchoice = Console.ReadLine();
                        if (logchoice.ToLower() == "y")
                        {
                            LogIn();
                            break;
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
        }

        static void LogIn()
        {
            Console.WriteLine("\nCarRenter or CarOwner");
            Console.WriteLine("1. CarRenter");
            Console.WriteLine("2. CarOwner");
            Console.WriteLine("3. Back");
            Console.Write("\nPlease select an option: ");

            // Request for user information
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter username: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    CarRenter foundUser = carRenters.Find(carRenter => carRenter.Username == name);
                    if (foundUser != null && foundUser.Password == password)
                    {
                        Console.WriteLine("Welcome back!");
                        while (true)
                        {
                            Console.WriteLine("\niCar System");
                            Console.WriteLine("1. Make a Booking");
                            Console.WriteLine("2. Display all Bookings");
                            Console.WriteLine("3. Exit");
                            Console.Write("\nPlease select an option: ");

                            string choice2 = Console.ReadLine();

                            switch (choice2)
                            {
                                case "1":
                                    MakeBooking();
                                    break;
                                case "2":
                                    DisplayAllBookings();
                                    break;
                                case "3":
                                    return;
                                default:
                                    Console.WriteLine("\nInvalid option. Please try again.\n");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password");
                        Console.WriteLine("Please try again!");
                        Console.WriteLine("\n");
                        LogIn();
                    }
                    break;
                case "2":
                    Console.Write("Enter username: ");
                    string name2 = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password2 = Console.ReadLine();
                    CarOwner foundUser2 = carOwners.Find(carOwner => carOwner.Username == name2);
                    if (foundUser2 != null && foundUser2.Password == password2)
                    {
                        Console.WriteLine("Welcome back!");
                        while (true)
                        {
                            Console.WriteLine("\niCar System");
                            Console.WriteLine("1. Add New Vehicle");
                            Console.WriteLine("2. Exit");
                            Console.Write("\nPlease select an option: ");

                            string choice2 = Console.ReadLine();

                            switch (choice2)
                            {
                                case "1":
                                    AddNewVehicle();
                                    break;
                                case "2":
                                    return;
                                default:
                                    Console.WriteLine("\nInvalid option. Please try again.\n");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password");
                        Console.WriteLine("Please try again!");
                        Console.WriteLine("\n");
                        LogIn();
                    }
                    break;
                case "3":
                    Console.WriteLine("\n");
                    Main();
                    break;
            }
        }

        static void CreateAccount()
        {

        }

        static void AddNewVehicle()
        {
            Console.WriteLine("Car Owner selects the add new vehicle option");

            // Car Details Entry
            string make, model, color, licensePlate;
            int year, mileage, rentalRate;
            bool insuranceStatus = false;
            string insuranceId = "";

            while (true)
            {
                Console.Write("Enter Car Maker:");
                make = Console.ReadLine();
                if (string.IsNullOrEmpty(make)) { Console.WriteLine("Car Make is required!"); continue; }

                Console.Write("Enter Car Model:");
                model = Console.ReadLine();
                if (string.IsNullOrEmpty(model)) { Console.WriteLine("Car Model is required!"); continue; }

                Console.Write("Enter Car Year:");
                if (!int.TryParse(Console.ReadLine(), out year)) { Console.WriteLine("Year must be an integer!"); continue; }

                Console.Write("Enter Car Mileage(km):");
                if (!int.TryParse(Console.ReadLine(), out mileage)) { Console.WriteLine("Mileage must be an integer!"); continue; }

                Console.Write("Enter Car Color:");
                color = Console.ReadLine();
                if (string.IsNullOrEmpty(color)) { Console.WriteLine("Car Color is required!"); continue; }

                Console.Write("Enter Car License Plate:");
                licensePlate = Console.ReadLine();
                if (string.IsNullOrEmpty(licensePlate)) { Console.WriteLine("License Plate is required!"); continue; }

                break;
            }

            Console.WriteLine("Car details successfully entered!");

            // Enter Insurance Details
            string insuranceName, policyStatus;
            int coverageLimit;
            DateTime expiryDate;

            while (true)
            {
                Console.WriteLine("Welcome to the Insurance terminal!");

                Console.Write("Enter Insurance ID:");
                insuranceId = Console.ReadLine();
                if (string.IsNullOrEmpty(insuranceId))
                {
                    Console.WriteLine("Please enter insurance info.");
                    continue;
                }

                Console.Write("Enter Insurance Name:");
                insuranceName = Console.ReadLine();
                if (string.IsNullOrEmpty(insuranceName)) { Console.WriteLine("Insurance Name is required!"); continue; }

                Console.Write("Enter Policy Status (e.g., active, expired):");
                policyStatus = Console.ReadLine();
                if (string.IsNullOrEmpty(policyStatus)) { Console.WriteLine("Policy Status is required!"); continue; }

                Console.Write("Enter Coverage Limit ($):");
                if (!int.TryParse(Console.ReadLine(), out coverageLimit)) { Console.WriteLine("Coverage Limit must be an integer!"); continue; }

                Console.Write("Enter Expiry Date (dd-mm-yyyy):");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out expiryDate))
                {
                    Console.WriteLine("Invalid date format! Please enter a valid expiry date.");
                    continue;
                }

                insuranceStatus = !string.IsNullOrEmpty(insuranceId);
                break;
            }

            Insurance newInsurance = new Insurance(insuranceId, expiryDate, coverageLimit, insuranceName, policyStatus);
            Console.WriteLine("Insurance successfully entered!");

            // Enter Rental Rate
            while (true)
            {
                Console.Write("Enter Rental Rate ($/day):");
                if (!int.TryParse(Console.ReadLine(), out rentalRate)) { Console.WriteLine("Rental Rate must be an integer!"); continue; }
                break;
            }

            // Enter Schedule
            DateTime startDate, endDate;
            List<DateTime> unavailableDates = new List<DateTime>();

            while (true)
            {
                while (true)
                {
                    Console.Write("Enter Start Date (dd-mm-yyyy):");
                    string startDateInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(startDateInput))
                    {
                        Console.Write("Please enter a start date!");
                        continue;
                    }
                    if (!DateTime.TryParseExact(startDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
                    {
                        Console.Write("Invalid date format! Please enter a valid start date.");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write("Enter End Date (dd-mm-yyyy):");
                    string endDateInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(endDateInput))
                    {
                        Console.Write("Please enter an end date!");
                        continue;
                    }
                    if (!DateTime.TryParseExact(endDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
                    {
                        Console.Write("Invalid date format! Please enter a valid end date.");
                        continue;
                    }
                    if (endDate < startDate)
                    {
                        Console.Write("End date cannot be earlier than start date. Please enter a valid end date.");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.WriteLine("Do you want to add unavailable dates within the selected range? (yes/no): ");
                    string addUnavailableDates = Console.ReadLine().ToLower();
                    if (addUnavailableDates == "yes")
                    {
                        while (true)
                        {
                            Console.Write("Enter an unavailable date (dd-mm-yyyy) within the range or type 'done' to finish: ");
                            string unavailableDateInput = Console.ReadLine();
                            if (unavailableDateInput.ToLower() == "done") break;

                            DateTime unavailableDate;
                            if (!DateTime.TryParseExact(unavailableDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out unavailableDate))
                            {
                                Console.Write("Invalid date format! Please enter a valid date.");
                                continue;
                            }
                            if (unavailableDate < startDate || unavailableDate > endDate)
                            {
                                Console.Write("Unavailable date must be within the selected range. Please enter a valid date.");
                                continue;
                            }
                            unavailableDates.Add(unavailableDate);
                        }
                    }
                    break;
                }

                Console.WriteLine("Date range added successfully!");

                Console.Write("Do you want to add more date ranges? (yes/no): ");
                string response = Console.ReadLine().ToLower();
                if (response != "yes")
                {
                    break;
                }
            }

            Console.WriteLine("All unavailable dates have been entered.");

            // Create Car Listing
            Car newCar = new Car(nextCarId++.ToString(), model, make, year, mileage, color, insuranceStatus, licensePlate, rentalRate);
            cars.Add(newCar);

            // Create Availability Schedule
            AvailabilitySchedule newSchedule = new AvailabilitySchedule(startDate, endDate, unavailableDates);
            availabilitySchedules.Add(newSchedule);

            Console.Write("Car listing and availability schedule created successfully!");

            // Display all cars
            Console.WriteLine("\nCurrent Car Listings:");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Brand} {car.Model} ({car.Year}) - ${car.RentalRate}/day");
            }

            // Display all availability schedules
            Console.WriteLine("\nCurrent Availability Schedules:");
            foreach (var schedule in availabilitySchedules)
            {
                Console.WriteLine($"Start Date: {schedule.StartDate:dd-MM-yyyy}, End Date: {schedule.EndDate:dd-MM-yyyy}");
                Console.WriteLine("Unavailable Dates:");
                foreach (var date in schedule.UnavailableDates)
                {
                    Console.WriteLine(date.ToString("dd-MM-yyyy"));
                }
            }
        }

        static void MakeBooking()
        {
            Console.WriteLine("Available cars:");
            foreach (var car in cars)
            {
                Console.WriteLine($"ID: {car.Id}, Model: {car.Model}, Brand: {car.Brand}, Year: {car.Year}, Mileage: {car.Mileage}, Color: {car.Color}, Rental Rate: {car.RentalRate}");
            }

            Console.Write("Enter vehicle ID: ");
            string input = Console.ReadLine();
            Car selectedCar = cars.Find(c => c.Id == input);

            if (selectedCar != null)
            {
                Console.WriteLine("Available pickup locations:");
                foreach (var loc in locations)
                {
                    Console.WriteLine($"ID: {loc.Id}, Address: {loc.Address}");
                }

                Console.Write("Enter pickup location ID: ");
                string location = Console.ReadLine();
                ICarStation selectedLocation = locations.Find(loc => loc.Id == location);
                if (selectedLocation != null)
                {

                    DateTime startDate;
                    DateTime endDate;
                    while (true)
                    {
                        Console.Write("Enter start date (yyyy-mm-dd): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out startDate))
                        {
                            Console.WriteLine("Invalid date format! Please enter a valid date.");
                            continue;
                        }

                        if (startDate < DateTime.Today)
                        {
                            Console.WriteLine("Start date cannot be before today's date. Please enter a valid start date.");
                            continue;
                        }

                        Console.Write("Enter end date (yyyy-mm-dd): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out endDate))
                        {
                            Console.WriteLine("Invalid date format! Please enter a valid date.");
                            continue;
                        }

                        if (endDate < DateTime.Today)
                        {
                            Console.WriteLine("End date cannot be before today's date. Please enter a valid end date.");
                            continue;
                        }

                        if (endDate >= startDate)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("End date cannot be before start date. Please re-enter the dates.");
                        }
                    }

                    // Calculate the total cost
                    TimeSpan rentalPeriod = endDate - startDate;
                    int rentalDays = rentalPeriod.Days + 1; // Include the start date as a rental day
                    decimal totalCost = rentalDays * selectedCar.RentalRate;
                    Console.WriteLine($"Total cost for the booking: ${totalCost}");

                    // Check for overlapping bookings
                    bool isAvailable = true;
                    foreach (var booking in bookings)
                    {
                        if (booking.Status == "Confirmed" && booking.StartDateTime < endDate && startDate < booking.EndDateTime)
                        {
                            isAvailable = false;
                            break;
                        }
                    }
                    if (isAvailable)
                    {
                        Booking newBooking = new Booking(Guid.NewGuid().ToString(), startDate, endDate, "Pending", false, location);
                        bookings.Add(newBooking);
                        Console.WriteLine("Booking created successfully.");

                        // Confirm booking and make payment
                        Console.Write("Do you want to confirm the booking and proceed to payment? (yes/no): ");
                        string confirm = Console.ReadLine();
                        if (confirm.ToLower() == "yes")
                        {
                            bool flag = true;
                            bool flag2 = true;
                            Console.WriteLine("Payment Methods:");
                            Console.WriteLine("a) Card");
                            Console.WriteLine("b) Mobile Wallet");
                            Console.WriteLine("c) Exit");
                            Console.Write("Select payment method: ");
                            string paymentType = Console.ReadLine();
                            while (flag)
                            {
                                switch (paymentType)
                                {
                                    case "a":
                                        // Handle Card payment method
                                        Console.WriteLine("Card payment selected.");
                                        Console.Write("Name registered under Mobile Wallet: ");
                                        string name = Console.ReadLine();
                                        Console.Write("Balance in Mobile Wallet (2dp): ");
                                        decimal balance = decimal.Parse(Console.ReadLine());
                                        Console.Write("PhoneNo registered under Mobile Wallet: ");
                                        string phoneNo = Console.ReadLine();
                                        MobileWallet mobileWallet = new MobileWallet("Mobile Wallet", balance, name, phoneNo);
                                        mobileWallet.MakePayment(totalCost);
                                        break;
                                    case "b":
                                        // Handle Mobile Wallet payment method
                                        Console.WriteLine("Mobile Wallet payment selected.");
                                        break;
                                    case "c":
                                        flag = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid selection.");
                                        break;
                                }
                            }
                            Console.WriteLine("Processing payment...");
                            newBooking.Status = "Confirmed";
                            newBooking.ConfirmedStatus = true;
                            Console.WriteLine("Booking confirmed and payment successful.");
                        }
                        else
                        {
                            Console.WriteLine("Booking not confirmed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The selected car is not available for the chosen dates.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid vehicle ID.");
                }
            }
        }

            static void DisplayAllBookings()
            {
                if (bookings.Count == 0)
                {
                    Console.WriteLine("No bookings available.");
                    return;
                }

                Console.WriteLine("All Bookings:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Booking ID: {booking.Id}");
                    Console.WriteLine($"Start Date: {booking.StartDateTime:yyyy-MM-dd}");
                    Console.WriteLine($"End Date: {booking.EndDateTime:yyyy-MM-dd}");
                    Console.WriteLine($"Status: {booking.Status}");
                    Console.WriteLine($"Confirmed: {booking.ConfirmedStatus}");
                    Console.WriteLine(new string('-', 30));
                }
            }
        


        private static int getUniqueID = 1;
        static int UniqueID()
        {
            return getUniqueID++;
        }
        static void CreateNewRenterAccount()
        {
            Console.WriteLine("\nEnter Username:");
            string username = Console.ReadLine();

            Console.WriteLine("\nEnter Password:");
            string password = Console.ReadLine();

            string email;
            while (true)
            {
                Console.WriteLine("\nEnter Email:");
                email = Console.ReadLine();
                if (email.Contains("@") && email.Contains("."))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email.");
                }
            }

            string id = UniqueID().ToString();

            int phoneNumber;
            while (true)
            {
                Console.Write("Enter Phone Number: ");
                string phoneNumberInput = Console.ReadLine();

                if (phoneNumberInput.Length == 8 && (phoneNumberInput.StartsWith("8") || phoneNumberInput.StartsWith("9")) && int.TryParse(phoneNumberInput, out phoneNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid phone number. It must start with 8 or 9 and be 8 digits long.");
                }
            }
            DateTime dob;
            while (true)
            {
                Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
                string dobInput = Console.ReadLine();

                if (DateTime.TryParseExact(dobInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                {
                    int age = DateTime.Now.Year - dob.Year;
                    if (dob > DateTime.Now.AddYears(-age)) age--;
                    if (age >= 18)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You cannot register as you are underage.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in YYYY-MM-DD format.");
                }
            }
            int monthlyFee = 0;
            bool isPrime = false;
            bool isVerified = false;
            string licenseId;
            while (true)
            {
                Console.Write("Enter License ID (Format: One letter, seven digits, one letter): ");
                licenseId = Console.ReadLine();
                if (licenseId.Length == 9 &&
                    char.IsLetter(licenseId[0]) &&
                    char.IsLetter(licenseId[8]) &&
                    int.TryParse(licenseId.Substring(1, 7), out _))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid License ID format. It must be one letter, followed by seven digits, followed by one letter.");
                }
            }

            CarRenter newCarRenter = new CarRenter(username,password, id, phoneNumber, email, monthlyFee, dob, isPrime, licenseId, isVerified);
            renters.Add(newCarRenter);
            Console.WriteLine("\nNew Renter Account Created:");
            Console.WriteLine($"Name: {username}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Date of Birth: {dob:yyyy-MM-dd}");
            Console.WriteLine($"License ID: {licenseId}");
        }


        static void CreateNewOwnerAccount()
        {
            Console.WriteLine("\nEnter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("\nEnter Username:");
            string password = Console.ReadLine();

            string email;
            while (true)
            {
                Console.WriteLine("\nEnter Email:");
                email = Console.ReadLine();
                if (email.Contains("@") && email.Contains("."))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email.");
                }
            }

            string id = UniqueID().ToString();

            int phoneNumber;
            while (true)
            {
                Console.Write("Enter Phone Number: ");
                string phoneNumberInput = Console.ReadLine();

                if (phoneNumberInput.Length == 8 && (phoneNumberInput.StartsWith("8") || phoneNumberInput.StartsWith("9")) && int.TryParse(phoneNumberInput, out phoneNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid phone number. It must start with 8 or 9 and be 8 digits long.");
                }
            }

            DateTime dob;
            while (true)
            {
                Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
                string dobInput = Console.ReadLine();

                if (DateTime.TryParseExact(dobInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                {
                    int age = DateTime.Now.Year - dob.Year;
                    if (dob > DateTime.Now.AddYears(-age)) age--;
                    if (age >= 18)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You cannot register as you are underage.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in YYYY-MM-DD format.");
                }
            }
            int earnings = 0;

            CarOwner newCarOwner = new CarOwner(username, password, id,phoneNumber, dob, email, earnings);
            carOwners.Add(newCarOwner);

            Console.WriteLine("\nNew Car Owner Account Created:");
            Console.WriteLine($"Name: {username}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Date of Birth: {dob:yyyy-MM-dd}");
        }
    }
}