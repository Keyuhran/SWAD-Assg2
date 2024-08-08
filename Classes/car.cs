using System;
using System.Collections.Generic;

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
        private List<AvailabilitySchedule> availabilitySchedules;

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
    }
}
