// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Car
    {
        public string Id {get; set;}
        public string Model {get; set;}
        public string Brand {get; set;}
        public int Year {get; set;}
        public int Mileage {get; set;}
        public string Color {get; set;}
        public bool InsuranceStatus {get; set;}
        public string LicensePlate {get; set;}
        public int RentalRate {get; set;}
        


        public Car() {}

        public Car(string id, string model, string brand, int year, int mileage, string color, bool insuranceStatus, string licensePlate, int rentalRate)
        {
            Id = id;
            Model = model;
            Brand = brand;
            Year = year;
            Mileage = mileage;
            Color = color;
            InsuranceStatus = insuranceStatus;
            LicensePlate = licensePlate;
            RentalRate = rentalRate;
        
        }

    }
}