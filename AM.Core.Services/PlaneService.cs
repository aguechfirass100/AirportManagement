using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class PlaneService
    {
        private readonly List<Plane> Planes;

        public PlaneService()
        {
            Planes = new List<Plane>();
        }

        public void AddPlane(int planeId, int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Plane existingPlane = Planes.FirstOrDefault(p => p.PlaneId == planeId);

            if (existingPlane != null)
            {
                Console.WriteLine("Plane with this ID already exists.");
                return;
            }

            Plane plane = new Plane
            {
                PlaneId = planeId,
                Capacity = capacity,
                ManufactureDate = manufactureDate,
                PlaneType = planeType
            };

            Planes.Add(plane);

            Console.WriteLine($"Plane ID: {plane.PlaneId} added successfully!");
        }

        public Plane GetPlane(int planeId)
        {
            return Planes.FirstOrDefault(p => p.PlaneId == planeId);
        }
    }
}
