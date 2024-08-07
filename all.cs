using System;
using System.Collections.Generic;

namespace SWAD_Team4_assignment_2
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public User(string username, string password, string id, int phoneNumber, string email)
        {
            Username = username;
            Password = password;
            Id = id;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Review
    {
        public string Id { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Review(string id, int stars, string description, DateTime date)
        {
            Id = id;
            Stars = stars;
            Description = description;
            Date = date;
        }
    }

    public class Listing
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
        public bool Availability { get; set; }

        public Listing(string id, int price, string address, bool availability)
        {
            Id = id;
            Price = price;
            Address = address;
            Availability = availability;
        }
    }

    public class Insurance
    {
        public string Id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int CoverageLimit { get; set; }
        public string Name { get; set; }
        public string PolicyStatus { get; set; }

        public Insurance(string id, DateTime expiryDate, int coverageLimit, string name, string policyStatus)
        {
            Id = id;
            ExpiryDate = expiryDate;
            CoverageLimit = coverageLimit;
            Name = name;
            PolicyStatus = policyStatus;
        }
    }

    public class ICarStation
    {
        public string Id { get; set; }
        public string Address { get; set; }

        public ICarStation(string id, string address)
        {
            Id = id;
            Address = address;
        }
    }

    public class Delivery
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }

        public Delivery(string id, DateTime date, string address)
        {
            Id = id;
            Date = date;
            Address = address;
        }
    }

    public class Car
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public bool InsuranceStatus { get; set; }
        public string LicensePlate { get; set; }
        public int RentalRate { get; set; }

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

    public class Booking
    {
        public string Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Status { get; set; }
        public bool ConfirmedStatus { get; set; }

        public Booking(string id, DateTime startDateTime, DateTime endDateTime, string status, bool confirmedStatus)
        {
            Id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            ConfirmedStatus = confirmedStatus;
        }
    }

    public class CarOwner : User
    {
        public double Earnings { get; set; }

        public CarOwner(string username, string password, string id, int phoneNumber, string email, double earnings) : base(username, password, id, phoneNumber, email)
        {
            Earnings = earnings;
        }
    }

    public class ICarAdmin : User
    {
        public string StaffId { get; set; }

        public ICarAdmin(string username, string password, string id, int phoneNumber, string email, string staffId) : base(username, password, id, phoneNumber, email)
        {
            StaffId = staffId;
        }
    }
}

namespace SWAD_Assg2
{
    using SWAD_Team4_assignment_2;

    public class PaymentMethod
    {
        public string Id { get; set; }
        public string Type { get; set; }

        public PaymentMethod(string id, string type)
        {
            Id = id;
            Type = type;
        }
    }

    public class MobileWallet : PaymentMethod
    {
        public string Name { get; set; }
        public string TransactionId { get; set; }

        public MobileWallet(string id, string type, string name, string transactionId) : base(id, type)
        {
            Name = name;
            TransactionId = transactionId;
        }
    }

    public class Card : PaymentMethod
    {
        public string CardNo { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string HolderName { get; set; }

        public Card(string id, string type, string cardNo, DateTime expiryDate, string holderName) : base(id, type)
        {
            CardNo = cardNo;
            ExpiryDate = expiryDate;
            HolderName = holderName;
        }
    }
}
