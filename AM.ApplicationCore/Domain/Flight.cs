﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }

        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();


        public Flight() { }

        public Flight(int flightId, string departure, string destination, DateTime effectiveArrival,
                      int estimatedDuration, DateTime flightDate, Plane plane)
        {
            FlightId = flightId;
            Departure = departure;
            Destination = destination;
            EffectiveArrival = effectiveArrival;
            EstimatedDuration = estimatedDuration;
            FlightDate = flightDate;
            Plane = plane;
        }

        public override string ToString()
        {
            return $"Flight ID: {FlightId}, \nDeparture: {Departure}, \nDestination: {Destination}, \n" +
                   $"Effective Arrival: {EffectiveArrival}, \nEstimated Duration: {EstimatedDuration} mins, \n" +
                   $"Flight Date: {FlightDate.ToShortDateString()}, \nPlane ID: {Plane?.PlaneId}";
        }
    }
}