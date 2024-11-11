using AM.ApplicationCore.Domain;
using System;
using System.Numerics;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.Core.Services
{
    public class FlightService
    {
        public IList<Flight> Flights { get; set; }
        //public IList<Plane> Planes { get; set; }
        private readonly PlaneService planeService;

        public FlightService(PlaneService planeService)
        {
            Flights = new List<Flight>();
            this.planeService = planeService;
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();

            foreach (Flight flight in Flights)
            {
                if(flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    flightDates.Add(flight.FlightDate);
                }
            }

            return flightDates;
        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> FilteredFlights = new List<Flight>();

            foreach (Flight flight in Flights)
            {
                var propertyInfo = typeof(Flight).GetProperty(filterType);

                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(flight)?.ToString();

                    if (propertyValue != null && propertyValue.Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    {
                        FilteredFlights.Add(flight);
                    }
                }
            }

            return FilteredFlights;
        }

        public List<DateTime> GetFlightDatesLINQ(string destination)
        {
            return Flights
                .Where(flight => flight.Destination.Equals(destination,StringComparison.OrdinalIgnoreCase))
                .Select(flight => flight.FlightDate)
                .ToList();
        }

        public void ShowFlightDetails(int planeId)
        {
            var flightDetails = Flights
                .Where(flight => flight.Plane.PlaneId == planeId)
                .Select(flight => new { flight.FlightId, flight.FlightDate, flight.Destination, flight.Plane.PlaneType, flight.Plane.Capacity });

            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Flight Number: {detail.FlightId}, Flight Date: {detail.FlightDate}, Destination: {detail.Destination}, Plane Model: {detail.PlaneType}, Plane Capacity: {detail.Capacity}");
            }
        }

        public int GetWeeklyFlightNumber(DateTime startDate)
        {
            var endDate = startDate.AddDays(7);

            return Flights
                .Count(flight => flight.FlightDate >= startDate && flight.FlightDate < endDate);
        }

        public double GetDurationAverage(string destination)
        {
            return Flights
                .Where(flight => flight.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                .Average(flight => flight.EstimatedDuration);
        }

        public List<Flight> SortFlights()
        {
            return Flights
                .OrderByDescending(Flight => Flight.EstimatedDuration)
                .ToList();
        }

        public List<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            return flight.Passengers
                .OrderByDescending(passenger => passenger.BirthDate)
                .Take(3)
                .ToList();
        }

        public void ShowGroupedFlights()
        {
            var groupedFlights = Flights
                .GroupBy(flight => flight.Destination)
                .OrderBy(group => group.Key); // hedhi optional, juste bech na3mlou sort lel destinations names

            foreach (var group in groupedFlights)
            {
                Console.WriteLine($"Destination: {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"\tFlight ID: {flight.FlightId}, Flight Date: {flight.FlightDate}");
                }
            }
        }

        public void AddFlightWithPlane(int flightId, DateTime flightDate, string destination, int planeId)
        {
            Plane plane = planeService.GetPlane(planeId);

            if (plane == null)
            {
                Console.WriteLine("Plane not found. Ensure the plane is added first.");
                return;
            }

            var flight = new Flight
            {
                FlightId = flightId,
                FlightDate = flightDate,
                Destination = destination,
                Plane = plane
            };

            Flights.Add(flight);

            Console.WriteLine($"Flight ID: {flight.FlightId} added successfully!");
            Console.WriteLine($"Flight Date: {flight.FlightDate}, Destination: {flight.Destination}");
            Console.WriteLine($"Plane Model: {flight.Plane.PlaneType}, Plane Capacity: {flight.Plane.Capacity}");
        }

        

    }
}
