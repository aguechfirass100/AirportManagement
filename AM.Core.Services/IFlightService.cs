using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;

namespace AM.Core.Services
{
    internal interface IFlightService
    {
        IList<Flight> Flights { get; set; }

        List<DateTime> GetFlightDates(string destination);

        List<Flight> GetFlights(string filterType, string filterValue);

        List<DateTime> GetFlightDatesLINQ(string destination);

        void ShowFlightDetails(int planeId);

        int GetWeeklyFlightNumber(DateTime startDate);

        double GetDurationAverage(string destination);

        List<Flight> SortFlights();

        List<Passenger> GetThreeOlderTravellers(Flight flight);

        void ShowGroupedFlights();
    }
}
