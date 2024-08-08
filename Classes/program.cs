using System;
using System.Collections.Generic;
using System.Globalization;

namespace SWAD_Team4_assignment_2
{
    class Program
    {
        static List<Car> cars = new List<Car>();
        static List<CarRenter> carRenters = new List<CarRenter>();
        static List<CarOwner> carOwners = new List<CarOwner>();
        static List<AvailabilitySchedule> availabilitySchedules = new List<AvailabilitySchedule>();
        static List<Booking> bookings = new List<Booking>();
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
                                    MakeBooking(foundUser);
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
                            Console.WriteLine("2. Car Availability Schedule");
                            Console.WriteLine("3. Exit");
                            Console.Write("\nPlease select an option: ");

                            string choice2 = Console.ReadLine();

                            switch (choice2)
                            {
                                case "1":
                                    AddNewVehicle();
                                    break;
                                case "2":
                                    DisplayCarAvailabilityScheduleById();
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
                case "3":
                    Console.WriteLine("\n");
                    Main();
                    break;
            }
        }

        static void CreateAccount()
        {
            Console.WriteLine("1. Create CarRenter Account");
            Console.WriteLine("2. Create CarOwner Account");
            Console.Write("\nPlease select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewRenterAccount();
                    break;
                case "2":
                    CreateNewOwnerAccount();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
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
                if (!email.Contains("@") || !email.Contains("."))
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email.");
                    continue;
                }

                bool emailExists = carRenters.Exists(renter => renter.Email == email);

                if (emailExists)
                {
                    Console.WriteLine("This email is already registered. Please use a different email.");
                }
                else
                {
                    break;
                }
            }

            string id = UniqueID().ToString();

            int phoneNumber;
            while (true)
            {
                Console.Write("\nEnter Phone Number: ");
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
                Console.Write("\nEnter Date of Birth (YYYY-MM-DD): ");
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
                Console.Write("\nEnter License ID (Format: One letter, seven digits, one letter): ");
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

            CarRenter newCarRenter = new CarRenter(username, password, id, phoneNumber, email, monthlyFee, dob, isPrime, licenseId, isVerified);
            carRenters.Add(newCarRenter);
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
            Console.WriteLine("\nEnter Password:");
            string password = Console.ReadLine();

            string email;
            while (true)
            {
                Console.WriteLine("\nEnter Email:");
                email = Console.ReadLine();
                if (!email.Contains("@") || !email.Contains("."))
                {
                    Console.WriteLine("Invalid email format. Please enter a valid email.");
                    continue;
                }

                bool emailExists = carOwners.Exists(owner => owner.Email == email);

                if (emailExists)
                {
                    Console.WriteLine("This email is already registered. Please use a different email.");
                }
                else
                {
                    break;
                }
            }

            string id = UniqueID().ToString();

            int phoneNumber;
            while (true)
            {
                Console.WriteLine("\nEnter Phone Number: ");
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
                Console.WriteLine("\nEnter Date of Birth (YYYY-MM-DD): ");
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

            double earnings = 0;

            CarOwner newCarOwner = new CarOwner(username, password, id, phoneNumber, email, dob, earnings);
            carOwners.Add(newCarOwner);

            Console.WriteLine("\nNew Car Owner Account Created:");
            Console.WriteLine($"Name: {username}");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Date of Birth: {dob:yyyy-MM-dd}");
        }

        static int getUniqueID = 1;
        static int UniqueID()
        {
            return getUniqueID++;
        }

        static void AddNewVehicle()
        {
            Console.WriteLine("Car Owner selects the add new vehicle option");

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

                if (expiryDate < DateTime.Now)
                {
                    Console.WriteLine("Insurance expiry date cannot be in the past.");
                    continue;
                }

                insuranceStatus = !string.IsNullOrEmpty(insuranceId);
                break;
            }

            Insurance newInsurance = new Insurance(insuranceId, expiryDate, coverageLimit, insuranceName, policyStatus);
            Console.WriteLine("Insurance successfully entered!");

            while (true)
            {
                Console.Write("Enter Rental Rate ($/day):");
                if (!int.TryParse(Console.ReadLine(), out rentalRate)) { Console.WriteLine("Rental Rate must be an integer!"); continue; }
                break;
            }

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
                    if (startDate > newInsurance.ExpiryDate)
                    {
                        Console.Write("Start date cannot be after the insurance expiry date. Please enter a valid start date.");
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

                if (IsDateRangeOverlapping(startDate, endDate))
                {
                    Console.WriteLine("The entered date range overlaps with an existing schedule. Please try again.");
                    continue;
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

            Car newCar = new Car(nextCarId++.ToString(), model, make, year, mileage, color, insuranceStatus, licensePlate, rentalRate);
            cars.Add(newCar);

            AvailabilitySchedule newSchedule = new AvailabilitySchedule(startDate, endDate, unavailableDates);
            newCar.AddAvailabilitySchedule(newSchedule);

            Console.WriteLine("Car listing and availability schedule created successfully!");

            Console.WriteLine("\nCurrent Car Listings:");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Brand} {car.Model} ({car.Year}) - ${car.RentalRate}/day");
            }

            Console.WriteLine("\nCurrent Availability Schedules:");
            foreach (var car in cars)
            {
                foreach (var schedule in car.AvailabilitySchedules)
                {
                    Console.WriteLine($"Car: {car.Brand} {car.Model} ({car.Year})");
                    Console.WriteLine($"Start Date: {schedule.StartDate:dd-MM-yyyy}, End Date: {schedule.EndDate:dd-MM-yyyy}");
                    Console.WriteLine("Unavailable Dates:");
                    foreach (var date in schedule.UnavailableDates)
                    {
                        Console.WriteLine(date.ToString("dd-MM-yyyy"));
                    }
                }
            }
        }

        static bool IsDateRangeOverlapping(DateTime startDate, DateTime endDate)
        {
            foreach (var car in cars)
            {
                foreach (var schedule in car.AvailabilitySchedules)
                {
                    if ((startDate >= schedule.StartDate && startDate <= schedule.EndDate) ||
                        (endDate >= schedule.StartDate && endDate <= schedule.EndDate) ||
                        (startDate <= schedule.StartDate && endDate >= schedule.EndDate))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void DisplayCarAvailabilityScheduleById()
        {
            Console.Write("Enter Car ID to view availability schedule: ");
            string carId = Console.ReadLine();

            Car car = cars.Find(c => c.Id == carId);
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            Console.WriteLine($"\nAvailability Schedules for Car: {car.Brand} {car.Model} ({car.Year})");

            foreach (var schedule in car.AvailabilitySchedules)
            {
                Console.WriteLine($"Start Date: {schedule.StartDate:dd-MM-yyyy}, End Date: {schedule.EndDate:dd-MM-yyyy}");
                Console.WriteLine("Unavailable Dates:");
                foreach (var date in schedule.UnavailableDates)
                {
                    Console.WriteLine(date.ToString("dd-MM-yyyy"));
                }
            }
        }

        static void MakeBooking(CarRenter carRenter)
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
                DateTime startDate;
                DateTime endDate;
                while (true)
                {
                    Console.Write("Enter start date (yyyy-mm-dd): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out startDate) || startDate < DateTime.Today)
                    {
                        Console.WriteLine("Invalid start date. Please enter a valid date that is not in the past.");
                        continue;
                    }

                    Console.Write("Enter end date (yyyy-mm-dd): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out endDate) || endDate < startDate)
                    {
                        Console.WriteLine("Invalid end date. Please enter a valid date that is after the start date.");
                        continue;
                    }

                    break;
                }

                TimeSpan rentalPeriod = endDate - startDate;
                int rentalDays = rentalPeriod.Days + 1; // Include the start date as a rental day
                decimal totalCost = rentalDays * selectedCar.RentalRate;
                Console.WriteLine($"Total cost for the booking: ${totalCost}");

                bool isAvailable = !bookings.Any(booking => booking.Status == "Confirmed" && booking.StartDateTime < endDate && startDate < booking.EndDateTime);

                if (isAvailable)
                {
                    Booking newBooking = new Booking(Guid.NewGuid().ToString(), startDate, endDate, "Pending", false);
                    bookings.Add(newBooking);
                    Console.WriteLine("Booking created successfully.");

                    Console.Write("Do you want to confirm the booking and proceed to payment? (yes/no): ");
                    string confirm = Console.ReadLine();
                    if (confirm.ToLower() == "yes")
                    {
                        bool paymentCompleted = false;
                        while (!paymentCompleted)
                        {
                            Console.WriteLine("Payment Methods:");
                            Console.WriteLine("a) Card");
                            Console.WriteLine("b) Mobile Wallet");
                            Console.WriteLine("c) Exit");
                            Console.Write("\nSelect payment method: ");
                            string paymentType = Console.ReadLine();

                            switch (paymentType)
                            {
                                case "a":
                                    paymentCompleted = HandleCardPayment(carRenter, newBooking, totalCost);
                                    break;
                                case "b":
                                    paymentCompleted = HandleMobileWalletPayment(carRenter, newBooking, totalCost);
                                    break;
                                case "c":
                                    Console.WriteLine("Payment process exited.");
                                    return;
                                default:
                                    Console.WriteLine("Invalid selection. Please choose a valid payment method.");
                                    break;
                            }
                        }
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

        static bool HandleCardPayment(CarRenter carRenter, Booking newBooking, decimal totalCost)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Payment Methods:");
                Console.WriteLine("a) Create New Card");
                Console.WriteLine("b) Existing Card");
                Console.WriteLine("c) Back");
                Console.Write("\nSelect an option: ");
                string decision = Console.ReadLine();

                switch (decision)
                {
                    case "a":
                        Console.WriteLine("Card payment selected.");
                        Console.Write("Name of card holder: ");
                        string holderName = Console.ReadLine();
                        Console.Write("16 digit Card Number: ");
                        string cardNo = Console.ReadLine();
                        Console.Write("Balance in Bank Account (2dp): ");
                        decimal balance = decimal.Parse(Console.ReadLine());
                        Console.Write("Expiration Date (YYYY-MM-DD): ");
                        DateTime expiryDate = DateTime.Parse(Console.ReadLine());
                        Card card = new Card("Card", balance, cardNo, expiryDate, holderName);
                        Console.WriteLine(card.ToString());
                        Console.Write("Would you like to save this payment method? (Y/N) ");
                        string decision2 = Console.ReadLine();
                        if (decision2.ToLower() == "y")
                        {
                            carRenter.cards.Add(card);
                        }
                        Console.WriteLine("Attempting Payment...");
                        if (card.MakePayment(totalCost))
                        {
                            newBooking.Status = "Confirmed";
                            newBooking.ConfirmedStatus = true;
                            Console.WriteLine("Booking confirmed and payment successful.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Payment failure. Insufficient funds. Try Again.");
                        }
                        break;
                    case "b":
                        if (carRenter.cards.Count == 0)
                        {
                            Console.WriteLine("No cards saved.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Cards saved:");
                            for (int i = 0; i < carRenter.cards.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {carRenter.cards[i].ToString()}");
                            }
                            Console.Write("Choose which card to use: ");
                            int cardIndex = int.Parse(Console.ReadLine()) - 1;
                            Card savedCard = carRenter.cards[cardIndex];
                            if (savedCard.MakePayment(totalCost))
                            {
                                newBooking.Status = "Confirmed";
                                newBooking.ConfirmedStatus = true;
                                Console.WriteLine("Booking confirmed and payment successful.");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Payment failure. Insufficient funds. Try Again.");
                            }
                        }
                        break;
                    case "c":
                        return false;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            return false;
        }

        static bool HandleMobileWalletPayment(CarRenter carRenter, Booking newBooking, decimal totalCost)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Payment Methods:");
                Console.WriteLine("a) Link new Mobile Wallet");
                Console.WriteLine("b) Existing Mobile Wallet");
                Console.WriteLine("c) Back");
                Console.Write("\nSelect an option: ");
                string decision = Console.ReadLine();

                switch (decision)
                {
                    case "a":
                        Console.WriteLine("Mobile Wallet payment selected.");
                        Console.Write("Name registered under Mobile Wallet: ");
                        string name = Console.ReadLine();
                        Console.Write("Balance in Mobile Wallet (2dp): ");
                        decimal balance = decimal.Parse(Console.ReadLine());
                        Console.Write("Phone No registered under Mobile Wallet: ");
                        string phoneNo = Console.ReadLine();
                        MobileWallet mobileWallet = new MobileWallet("Mobile Wallet", balance, name, phoneNo);
                        Console.Write("Would you like to save this payment method? (Y/N) ");
                        string decision2 = Console.ReadLine();
                        if (decision2.ToLower() == "y")
                        {
                            carRenter.mobileWallets.Add(mobileWallet);
                        }
                        Console.WriteLine("Attempting Payment...");
                        if (mobileWallet.MakePayment(totalCost))
                        {
                            newBooking.Status = "Confirmed";
                            newBooking.ConfirmedStatus = true;
                            Console.WriteLine("Booking confirmed and payment successful.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Payment failure. Insufficient funds. Try Again.");
                        }
                        break;
                    case "b":
                        if (carRenter.mobileWallets.Count == 0)
                        {
                            Console.WriteLine("No mobile wallets previously linked.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Mobile Wallets Linked:");
                            for (int i = 0; i < carRenter.mobileWallets.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {carRenter.mobileWallets[i].ToString()}");
                            }
                            Console.Write("Choose which mobile wallet to use: ");
                            int walletIndex = int.Parse(Console.ReadLine()) - 1;
                            MobileWallet savedWallet = carRenter.mobileWallets[walletIndex];
                            if (savedWallet.MakePayment(totalCost))
                            {
                                newBooking.Status = "Confirmed";
                                newBooking.ConfirmedStatus = true;
                                Console.WriteLine("Booking confirmed and payment successful.");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Payment failure. Insufficient funds. Try Again.");
                            }
                        }
                        break;
                    case "c":
                        return false;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            return false;
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
    }
}