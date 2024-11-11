using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AM.ApplicationCore.Domain;
public class Passenger
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    [MinLength(3, ErrorMessage = "First Name must be at least 3 characters long.")]
    [MaxLength(25, ErrorMessage = "First Name cannot exceed 25 characters.")]
    public FullName FullName { get; set; }

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Email Address is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string EmailAddress { get; set; }

    [MaxLength(7, ErrorMessage = "Passport Number must be exactly 7 characters long.")]
    public string PassportNumber { get; set; }

    public int TelNumber { get; set; }

    public int IsTraveller { get; set; }

    public int Age
    {
        get
        {
            int calculatedAge = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
            {
                calculatedAge--;
            }
            return calculatedAge;
        }
    }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();


    public Passenger() { }

    public Passenger(int id, FullName fullName, DateTime birthDate,
                     string emailAddress, string passportNumber, int telNumber)
    {
        Id = id;
        FullName = fullName;
        BirthDate = birthDate;
        EmailAddress = emailAddress;
        PassportNumber = passportNumber;
        TelNumber = telNumber;
    }

    public bool CheckProfile(FullName fullName)
    {
        return FullName.Equals(fullName);
    }

    public bool CheckProfile(FullName fullName, string emailAddress)
    {
        return CheckProfile(fullName) && EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"Passenger ID: {Id}, \nName: {FullName.ToString()}, \nBirth Date: {BirthDate.ToShortDateString()}, \n" +
               $"\nEmail: {EmailAddress}, \nPassport: {PassportNumber}, \nPhone: {TelNumber}, \nAge: {Age}";
    }

    public virtual string GetPassengerType()
    {
        return "I am a passenger";
    }

    public void GetAge(DateTime birthDate, ref int calculatedAge)
    {
        calculatedAge = DateTime.Now.Year - birthDate.Year;

        if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
        {
            calculatedAge--;
        }
    }

    // i commented this because we changed the Age to be read-only so we cannot change it.
    //public void GetAge(Passenger aPassenger)
    //{
    //    aPassenger.Age = DateTime.Now.Year - aPassenger.BirthDate.Year;

    //    if (DateTime.Now.DayOfYear < aPassenger.BirthDate.DayOfYear)
    //    {
    //        aPassenger.Age--;
    //    }
    //}

}
