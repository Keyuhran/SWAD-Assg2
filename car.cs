// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Car
    {
   
        private string id;
        private string model;
        private string brand;
        private int year;
        private int mileage;
        private string color;
        private bool insuranceStatus;
        private string licensePlate;
        private int rentalRate;
        
        

        public Car(string id, string model, string brand, int year, int mileage, string color, bool insuranceStatus, string licensePlate, int rentalRate)
        {
            this.id = id;
            this.model = model;
            this.brand = brand;
            this.year = year;
            this.mileage = mileage;
            this.color = color;
            this.insuranceStatus = insuranceStatus;
            this.licensePlate = licensePlate;
            this.rentalRate = rentalRate;
        }

        public string Id
        {
            get {return id; }
            set {id = value; }
        }
        public string Model
        {
            get {return model; }
            set {model = value; }
        }
        public string Brand
        {
            get {return brand; }
            set {brand = value; }
        }
        public string Year
        {
            get {return year; }
            set {year = value; }
        }
        public string Mileage
        {
            get {return mileage; }
            set {mileage = value; }
        }
        public string Color
        {
            get {return color; }
            set {color = value; }
        }
        public string InsuranceStatus
        {
            get {return insuranceStatus; }
            set {insuranceStatus = value; }
        }
        public string LicensePlate
        {
            get {return licensePlate; }
            set {licensePlate = value; }
        }
        public string RentalRate
        {
            get {return rentalRate; }
            set {rentalRate = value; }
        }
        

    }
}