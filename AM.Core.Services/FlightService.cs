using AM.ApplicationCore.Domain;

namespace AM.Core.Services
{
    public class FlightService
    {
        public IList<Flight> Flights { get; set; }

        public FlightService()
        {
            Flights = new List<Flight>();
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
                .Select(flight => new { flight.FlightDate, flight.Destination });

            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Flight Date: {detail.FlightDate}, Destination: {detail.Destination}");
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
    }
}
