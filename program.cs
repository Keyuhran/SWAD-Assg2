// See https://aka.ms/new-console-template for more information
using SWAD_Assg2;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace SWAD_Team4_assignment_2
{
    class Program
    {
        static List<Car> cars = new List<Car>();
        static List<CarOwner> carOwners = new List<CarOwner>();
        static List<ICarAdmin> ICarAdmins = new List<ICarAdmin>();

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
                        
                        break;
                    case "3":
                        
                        break;
                    case "4":
                        
                        break;
                    case "5":
                        
                        break;
                    case "6":
                        
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
                Console.WriteLine("Enter Car Make:");
                make = Console.ReadLine();
                if (string.IsNullOrEmpty(make)) { Console.WriteLine("Car Make is required!"); continue; }

                Console.WriteLine("Enter Car Model:");
                model = Console.ReadLine();
                if (string.IsNullOrEmpty(model)) { Console.WriteLine("Car Model is required!"); continue; }

                Console.WriteLine("Enter Car Year:");
                if (!int.TryParse(Console.ReadLine(), out year)) { Console.WriteLine("Year must be an integer!"); continue; }

                Console.WriteLine("Enter Car Mileage:");
                if (!int.TryParse(Console.ReadLine(), out mileage)) { Console.WriteLine("Mileage must be an integer!"); continue; }

                Console.WriteLine("Enter Car Color:");
                color = Console.ReadLine();
                if (string.IsNullOrEmpty(color)) { Console.WriteLine("Car Color is required!"); continue; }

                Console.WriteLine("Enter Car License Plate:");
                licensePlate = Console.ReadLine();
                if (string.IsNullOrEmpty(licensePlate)) { Console.WriteLine("License Plate is required!"); continue; }

                break;
            }

            Console.WriteLine("Car details successfully entered!");

            // Enter Insurance Details
            Console.WriteLine("Redirecting to Insurance Terminal...");
            Console.WriteLine("Enter Insurance ID:");
            insuranceId = Console.ReadLine();
            insuranceStatus = !string.IsNullOrEmpty(insuranceId);

            if (!insuranceStatus)
            {
                Console.WriteLine("Insurance not registered. Redirecting to 3rd party site...");
                // Simulation of redirecting to 3rd party site
                Console.WriteLine("Re-enter Insurance ID:");
                insuranceId = Console.ReadLine();
                insuranceStatus = !string.IsNullOrEmpty(insuranceId);
            }

            Console.WriteLine("Insurance successfully entered!");

            // Enter Rental Rate
            while (true)
            {
                Console.WriteLine("Enter Rental Rate ($/day):");
                if (!int.TryParse(Console.ReadLine(), out rentalRate)) { Console.WriteLine("Rental Rate must be an integer!"); continue; }
                break;
            }

            // Enter Schedule
            DateTime scheduleDate;
            while (true)
            {
                Console.WriteLine("Enter Schedule Date (e.g. 1/1/2024):");
                string dateInput = Console.ReadLine();
                if (string.IsNullOrEmpty(dateInput))
                {
                    Console.WriteLine("Please enter a date!");
                    continue;
                }
                if (!DateTime.TryParse(dateInput, out scheduleDate))
                {
                    Console.WriteLine("Invalid date format! Please enter a valid date.");
                    continue;
                }
                break;
            }

            // Create Car Listing
            Car newCar = new Car(Guid.NewGuid().ToString(), model, make, year, mileage, color, insuranceStatus, licensePlate, rentalRate);
            cars.Add(newCar);

            Console.WriteLine("Car listing created successfully!");

            // Display all cars
            Console.WriteLine("\nCurrent Car Listings:");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Brand} {car.Model} ({car.Year}) - ${car.RentalRate}/day");
            }
        }
    }
}
