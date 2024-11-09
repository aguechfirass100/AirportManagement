using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AM.ApplicationCore.Domain;
public class Passenger
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string EmailAddress { get; set; }
    public string PassportNumber { get; set; }
    public int TelNumber { get; set; }

    public ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public Passenger() { }

    public Passenger(int id, string firstName, string lastName, DateTime birthDate,
                     string emailAddress, string passportNumber, int telNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        EmailAddress = emailAddress;
        PassportNumber = passportNumber;
        TelNumber = telNumber;
    }

    public bool CheckProfile(string firstName, string lastName)
    {
        return FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) 
            && LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase);
    }

    public bool CheckProfile(string firstName, string lastName, string emailAddress)
    {
        return CheckProfile(firstName, lastName) && EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase);
    }

    public bool CheckProfile1(string firstName, string lastName, string emailAddress)
    {
        if (emailAddress == null)
        {
            return CheckProfile(firstName, lastName);
        }
        else
        {
            return CheckProfile(firstName, lastName, emailAddress);
        }
    }

    public virtual void PassengerType()
    {
        Console.WriteLine("I am a passenger");
    }

    public override string ToString()
    {
        return $"Passenger ID: {Id}, \nName: {FirstName} {LastName}, \nBirth Date: {BirthDate.ToShortDateString()}, \n" +
               $"\nEmail: {EmailAddress}, \nPassport: {PassportNumber}, \nPhone: {TelNumber}";
    }
}
