using AM.ApplicationCore.Domain;
using System;

namespace AM.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane1 = new Plane();

            plane1.PlaneId = 1;
            plane1.Capacity = 180;
            plane1.ManufactureDate = new DateTime(2020, 10, 30);
            plane1.PlaneType = PlaneType.Boeing;

            //Plane plane2 = new Plane(PlaneType.Airbus, 380, new DateTime(2015, 12, 12));

            Plane plane3 = new Plane
            {
                PlaneType = PlaneType.Boeing,
                Capacity = 240,
                ManufactureDate = new DateTime(2018, 5, 10)
            };


            Console.WriteLine(plane1.ToString());
            //Console.WriteLine(plane2.ToString());
            Console.WriteLine(plane3.ToString());


            Passenger passenger = new Passenger { FirstName = "Firass", LastName = "Aguech", EmailAddress = "firass@aguech.com" };
            Staff staff = new Staff { FirstName = "Ahmed", LastName = "Aguech", EmailAddress = "ahmed@aguech.com" };
            Traveller traveller = new Traveller { FirstName = "Lionel", LastName = "Messi", EmailAddress = "lionel@messi.com" };

            Console.WriteLine(passenger.CheckProfile("Firass", "Aguech"));
            Console.WriteLine(passenger.CheckProfile("Firass", "Aguech", "firass@aguech.com"));
            Console.WriteLine(passenger.CheckProfile("Firass", "Aguech", "wrong@aguech.com"));
            Console.WriteLine(passenger.CheckProfile("Firass", "Aguech", null));

            passenger.PassengerType();
            staff.PassengerType();
            traveller.PassengerType();
        }
    }
}
