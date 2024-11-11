using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{

    public enum PlaneType
    {
        Boeing,
        Airbus
    }

    public class Plane
    {
        public int PlaneId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive integer.")]
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }

        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

        public Plane() { }

        //public Plane(PlaneType pt, int capacity, DateTime date) 
        //{
        //    PlaneType = pt;
        //    Capacity = capacity;
        //    ManufactureDate = date;
        //}

        public Plane(int planeId, int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            PlaneId = planeId;
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }

        public override string ToString()
        {
            return $"Plane ID: {PlaneId}, \nCapacity: {Capacity}, \nManufacture Date: {ManufactureDate.ToShortDateString()}, \nPlane Type: {PlaneType}";
        }

    }
}
