using System;
using System.Collections.Generic;
using System.Globalization;
using SWAD_Assg2;

namespace SWAD_Team4_assignment_2
{
    class Program
    {
        static List<Car> cars = new List<Car>();
        static List<AvailabilitySchedule> availabilitySchedules = new List<AvailabilitySchedule>();
        static int nextCarId = 1; // Static counter for car IDs

        static void Main()
        {
            // Main menu
            while (true)
            {
                Console.WriteLine("Welcome to iCar Car Rental System");
                Console.WriteLine("1. Add New Vehicle");
                Console.WriteLine("2. ");
                Console.WriteLine("3. ");
                Console.WriteLine("4. ");
                Console.WriteLine("5. ");
                Console.WriteLine("6. ");
                Console.WriteLine("7. ");
                Console.Write("\nPlease select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewVehicle();
                        break;
                    case "2":
                        // Add functionality for option 2
                        break;
                    case "3":
                        // Add functionality for option 3
                        break;
                    case "4":
                        // Add functionality for option 4
                        break;
                    case "5":
                        // Add functionality for option 5
                        break;
                    case "6":
                        // Add functionality for option 6
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
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
        DateTime startDate;
        DateTime endDate;
        while (true)
        {
            Console.Write("Enter start date (yyyy-mm-dd): ");
            startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter end date (yyyy-mm-dd): ");
            endDate = DateTime.Parse(Console.ReadLine());

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
            Booking newBooking = new Booking(Guid.NewGuid().ToString(), startDate, endDate, "Pending", false);
            bookings.Add(newBooking);
            Console.WriteLine("Booking created successfully.");

            // Confirm booking and make payment
            Console.Write("Do you want to confirm the booking and proceed to payment? (yes/no): ");
            string confirm = Console.ReadLine();
            if (confirm.ToLower() == "yes")
            {
                // Simulate payment process
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
}