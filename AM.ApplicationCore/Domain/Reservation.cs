using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Reservation
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public decimal Price { get; set; }
        public string Seat { get; set; }
        public bool VIP { get; set; }

        public Reservation() { }

        public Reservation(int flightId, int passengerId, decimal price, string seat, bool vip)
        {
            FlightId = flightId;
            PassengerId = passengerId;
            Price = price;
            Seat = seat;
            VIP = vip;
        }
    }

}
