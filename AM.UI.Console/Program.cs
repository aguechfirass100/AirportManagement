using AM.ApplicationCore.Domain;
using AM.Core.Services;
using AM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;

namespace AM.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Plane plane1 = new Plane();

            //plane1.PlaneId = 1;
            //plane1.Capacity = 180;
            //plane1.ManufactureDate = new DateTime(2020, 10, 30);
            //plane1.PlaneType = PlaneType.Boeing;

            ////Plane plane2 = new Plane(PlaneType.Airbus, 380, new DateTime(2015, 12, 12));

            //Plane plane3 = new Plane
            //{
            //    PlaneType = PlaneType.Boeing,
            //    Capacity = 240,
            //    ManufactureDate = new DateTime(2018, 5, 10)
            //};


            //Console.WriteLine(plane1.ToString());
            ////Console.WriteLine(plane2.ToString());
            //Console.WriteLine(plane3.ToString());


            //Passenger passenger = new Passenger { FirstName = "Firass", LastName = "Aguech", EmailAddress = "firass@aguech.com" };
            //Staff staff = new Staff { FirstName = "Ahmed", LastName = "Aguech", EmailAddress = "ahmed@aguech.com" };
            //Traveller traveller = new Traveller { FirstName = "Lionel", LastName = "Messi", EmailAddress = "lionel@messi.com" };

            //Console.WriteLine(passenger.CheckProfile("Firass", "Aguech"));
            //Console.WriteLine(passenger.CheckProfile("Firass", "Aguech", "firass@aguech.com"));
            //Console.WriteLine(passenger.CheckProfile("Firass", "Aguech", "wrong@aguech.com"));
            //Console.WriteLine(passenger.CheckProfile("Firass", "Aguech", null));

            //string passengerType = passenger.GetPassengerType();
            //string staffType = staff.GetPassengerType();
            //string travellerType = traveller.GetPassengerType();

            //Console.WriteLine(passengerType);
            //Console.WriteLine(staffType);
            //Console.WriteLine(travellerType);

            //Passenger passenger1 = new Passenger(100, "John", "Doe", new DateTime(1990, 5, 15), "john.doe@example.com", "X123456789", 123456789);

            //int ageByValue = 0;
            //passenger1.GetAge(passenger1.BirthDate, ref ageByValue);
            //Console.WriteLine($"Age calculated by value (ref): {ageByValue}"); 

            //Console.WriteLine($"Passenger's Age (after GetAge by ref): {passenger1.Age}");  

            ////passenger1.GetAge(passenger1);
            //Console.WriteLine($"Passenger's Age (after GetAge by reference): {passenger1.Age}");

            //Console.WriteLine(passenger1.ToString()); 

            //Console.WriteLine($"Calculated Age: {passenger1.Age}");

            //Console.ReadLine();

            //using var context = new AMContext();

            //var plane = new Plane
            //{
            //    Capacity = 180,
            //    ManufactureDate = new DateTime(2015, 5, 10),
            //    PlaneType = PlaneType.Airbus
            //};

            //context.Planes.Add(plane);
            //context.SaveChanges();

            //var flight = new Flight
            //{
            //    Departure = "New York",
            //    Destination = "London",
            //    FlightDate = DateTime.Now,
            //    EffectiveArrival = DateTime.Now.AddHours(7),
            //    EstimatedDuration = 420,
            //    Comment = "On time",
            //    Plane = plane
            //};

            //context.Flights.Add(flight);
            //context.SaveChanges();

            //Console.WriteLine("Flight with comment added successfully!");


            //PlaneService planeService = new PlaneService();
            //FlightService flightService = new FlightService(planeService);

            //planeService.AddPlane(10, 150, new DateTime(2010, 5, 15), PlaneType.Boeing);

            //flightService.AddFlightWithPlane(101, new DateTime(2024, 12, 25), "Paris", 10);

            //Console.WriteLine("\nFlights in the system:");
            //foreach (var flight in flightService.Flights)
            //{
            //    Console.WriteLine($"Flight ID: {flight.FlightId}, Destination: {flight.Destination}, Plane: {flight.Plane.PlaneType}");
            //}

            //using (var context = new AMContextFactory().CreateDbContext(null))
            //{
            //    var flight = context.Flights
            //        .Include(f => f.Plane) // Explicitly load the related Plane
            //        .FirstOrDefault(f => f.FlightId == 2);

            //    if (flight != null)
            //    {
            //        Console.WriteLine($"Flight ID: {flight.FlightId}");
            //        Console.WriteLine($"Destination: {flight.Destination}");
            //        Console.WriteLine($"Flight Date: {flight.FlightDate}");

            //        if (flight.Plane != null)
            //        {
            //            Console.WriteLine($"Plane Type: {flight.Plane.PlaneType}");
            //            Console.WriteLine($"Plane Capacity: {flight.Plane.Capacity}");
            //            Console.WriteLine($"Manufacture Date: {flight.Plane.ManufactureDate}");
            //        }
            //        else
            //        {
            //            Console.WriteLine("No plane associated with this flight.");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Flight not found.");
            //    }
            //}

            using (var context = new AMContextFactory().CreateDbContext(null))
            {
                var flight = context.Flights.FirstOrDefault(f => f.FlightId == 2);

                Console.WriteLine("################################################################");

                if (flight != null)
                {
                    Console.WriteLine($"Flight ID: {flight.FlightId}");
                    Console.WriteLine($"Flight Date: {flight.FlightDate}");
                    Console.WriteLine($"Destination: {flight.Destination}");

                    var plane = flight.Plane;

                    if (plane != null)
                    {
                        Console.WriteLine($"Plane Type: {plane.PlaneType}");
                        Console.WriteLine($"Plane Capacity: {plane.Capacity}");
                        Console.WriteLine($"Manufacture Date: {plane.ManufactureDate.ToShortDateString()}");
                    }
                    else
                    {
                        Console.WriteLine("No plane associated with this flight.");
                    }
                }
                else
                {
                    Console.WriteLine("Flight not found.");
                }

                Console.WriteLine("################################################################");
            }



        }
    }
}
