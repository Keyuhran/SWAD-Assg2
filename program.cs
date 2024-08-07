// See https://aka.ms/new-console-template for more information
using SWAD_Assg2;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace SWAD_Team4_assignment_2
{
    class Program
    {
        //static List<Car> cars = new List<Car>();
        //static List<CarOwner> carOwners = new List<CarOwner>();
        //static List<ICarAdmin> ICarAdmins = new List<ICarAdmin>();

  

        static void Main()
        {
           

            // Main menu
            while (true)
            {
                Console.WriteLine("Welcome to iCar Car Rental System");
                Console.WriteLine("1. ");
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
                        ();
                        break;
                    case "2":
                        ();
                        break;
                    case "3":
                        ();
                        break;
                    case "4":
                        ();
                        break;
                    case "5":
                        ();
                        break;
                    case "6":
                        ();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }
            }
        }

        
    }
}


