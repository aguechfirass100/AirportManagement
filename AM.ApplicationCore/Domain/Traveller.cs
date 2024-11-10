using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Traveller : Passenger
{
    public string HealthInformation { get; set; }
    public string Nationality { get; set; }

    //public string TravellerSpecificProperty { get; set; }

    public Traveller() { }

    public Traveller(int id, FullName fullName, DateTime birthDate,
                     string emailAddress, string passportNumber, int telNumber,
                     string healthInformation, string nationality)
        : base(id, fullName, birthDate, emailAddress, passportNumber, telNumber)
    {
        HealthInformation = healthInformation;
        Nationality = nationality;
    }

    public override string GetPassengerType()
    {
        return "I am a Traveller";
    }

    public override string ToString()
    {
        return base.ToString() + $", Health Information: {HealthInformation}, Nationality: {Nationality}";
    }
}
