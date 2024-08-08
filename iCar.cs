using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Team4_assignment_2
{
    public class User
    {
        private string username;
        private string password;
        private string id;
        private int phoneNumber;
        private string email;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User(string username, string password, string id, int phoneNumber, string email)
        {
            this.username = username;
            this.password = password;
            this.id = id;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }
    }

    public class ICarAdmin : User
    {
        private string staffid;

        public string Staffid
        {
            get { return staffid; }
            set { staffid = value; }
        }

        public ICarAdmin(string username, string password, string id, int phoneNumber, string email, string staffid) : base(username, password, id, phoneNumber, email)
        {
            this.staffid = staffid;

        }
    }

    class CarOwner : User
    {
        private double earnings;

        public CarOwner(string username, string password, string id, int phoneNumber, string email, DateTime dob, double earnings) : base(username, password, id, phoneNumber, email)
        {
            this.earnings = earnings;
            this.Cars = new List<Car>();

        }
        public double Earnings
        {
            get { return earnings; }
            set { earnings = value; }
        }

        public List<Car> Cars { get; set; }
    }

    public class CarRenter : User
    {
        private int monthlyFee;
        private DateTime dob;
        private bool isPrime;
        private string licenseid;
        private bool isVerified;

        public int MonthlyFee
        {
            get { return monthlyFee; }
            set { monthlyFee = value; }
        }
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        public bool IsPrime
        {
            get { return isPrime; }
            set { isPrime = value; }
        }
        public string Licenseid
        {
            get { return licenseid; }
            set { licenseid = value; }
        }
        public bool IsVerified
        {
            get { return isVerified; }
            set { isVerified = value; }
        }

        public List<Booking> Bookings { get; set; }
        public List<MobileWallet> mobileWallets { get; set; }
        public List<Card> cards { get; set; }

        public CarRenter(string username, string password, string id, int phoneNumber, string email, int monthlyFee, DateTime dob, bool isPrime, string licenseid, bool isVerified) : base(username, password, id, phoneNumber, email)
        {
            this.monthlyFee = monthlyFee;
            this.dob = dob;
            this.isPrime = isPrime;
            this.licenseid = licenseid;
            this.isVerified = isVerified;
            this.Bookings = new List<Booking>();
            this.mobileWallets =  new List<MobileWallet>();
            this.cards = new List<Card>();

        }
    }

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
        private List<AvailabilitySchedule> availabilitySchedules;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public bool InsuranceStatus
        {
            get { return insuranceStatus; }
            set { insuranceStatus = value; }
        }
        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }
        public int RentalRate
        {
            get { return rentalRate; }
            set { rentalRate = value; }
        }
        public List<AvailabilitySchedule> AvailabilitySchedules
        {
            get { return availabilitySchedules; }
            set { availabilitySchedules = value; }
        }

        public void AddAvailabilitySchedule(AvailabilitySchedule schedule)
        {
            availabilitySchedules.Add(schedule);
        }

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
            this.availabilitySchedules = new List<AvailabilitySchedule>();
        }
    }

    public class Review
    {

        private string id;
        private int stars;
        private string description;
        private DateTime date;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Stars
        {
            get { return stars; }
            set { stars = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Review(string id, int stars, string description, DateTime date)
        {
            this.id = id;
            this.stars = stars;
            this.description = description;
            this.date = date;

        }
    }

    public class PaymentMethod
    {
        private string type;
        private decimal balance;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public PaymentMethod(string type, decimal balance)
        {   
            this.type = type;
            this.balance = balance;
        }

        public virtual bool MakePayment(decimal totalAmount)
        {
            return true;
        }
    }

    public class MobileWallet : PaymentMethod
    {
        private string name;
        private string phoneNo;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        public MobileWallet(string type, decimal balance, string name, string phoneNo) : base(type, balance)
        {
            this.name = name;
            this.phoneNo = phoneNo;
        }

        public override bool MakePayment(decimal totalAmount)
        {
            if (totalAmount <= Balance)
            {
                Balance -= totalAmount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"MobileWallet: Name={name}, PhoneNo={phoneNo}, Type={Type}, Balance={Balance:C}";
        }
    }

    public class Card : PaymentMethod
    {
        private string cardNo;
        private DateTime expiryDate;
        private string holderName;

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public string HolderName
        {
            get { return holderName; }
            set { holderName = value; }
        }

        public Card(string type, decimal balance, string cardNo, DateTime expiryDate, string holderName) : base(type, balance)
        {
            this.cardNo = cardNo;
            this.expiryDate = expiryDate;
            this.holderName = holderName;
        }

        public override bool MakePayment(decimal totalAmount)
        {
            if (totalAmount <= Balance)
            {
                Balance -= totalAmount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Card: HolderName={holderName}, CardNo={cardNo}, ExpiryDate={expiryDate:MM/yy}, Type={Type}, Balance={Balance:C}";
        }
    }


    public class Listing
    {
        private string id;
        private int price;
        private string address;
        private bool availability;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        public Listing(string id, int price, string address, bool availability)
        {
            this.id = id;
            this.price = price;
            this.address = address;
            this.availability = availability;

        }
    }

    public class Insurance
    {
        private string id;
        private DateTime expiryDate;
        private int coverageLimit;
        private string name;
        private string policyStatus;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }
        public int CoverageLimit
        {
            get { return coverageLimit; }
            set { coverageLimit = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PolicyStatus
        {
            get { return policyStatus; }
            set { policyStatus = value; }
        }

        public Insurance(string id, DateTime expiryDate, int coverageLimit, string name, string policyStatus)
        {
            this.id = id;
            this.expiryDate = expiryDate;
            this.coverageLimit = coverageLimit;
            this.name = name;
            this.policyStatus = policyStatus;

        }
    }

    public class ICarStation
    {
        private string id;
        private string address;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public ICarStation(string id, string address)
        {
            this.id = id;
            this.address = address;

        }
    }

    public class Delivery
    {
        private string id;
        private DateTime date;
        private string address;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Delivery(string id, DateTime date, string address)
        {
            this.id = id;
            this.date = date;
            this.address = address;

        }
    }

    public class Booking
    {
        private string id;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private string status;
        private bool confirmedStatus;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public bool ConfirmedStatus
        {
            get { return confirmedStatus; }
            set { confirmedStatus = value; }
        }

        public Booking(string id, DateTime startDate, DateTime endDate, string status, bool confirmedStatus)
        {
            this.id = id;
            this.startDateTime = startDate;
            this.endDateTime = endDate;
            this.status = status;
            this.confirmedStatus = confirmedStatus;
        }
    }

    public class AvailabilitySchedule
    {
        private DateTime startDate;
        private DateTime endDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        public List<DateTime> UnavailableDates { get; set; }

        public AvailabilitySchedule(DateTime startDate, DateTime endDate, List<DateTime> unavailableDates)
        {
            StartDate = startDate;
            EndDate = endDate;
            UnavailableDates = unavailableDates;
        }
    }
}
