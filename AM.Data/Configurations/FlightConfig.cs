using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configurations
{
    public class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("MyFlights");

            builder.HasKey(f => f.FlightId);

            builder.HasOne(f => f.Plane)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.PlaneId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.Reservations)
               .WithOne(r => r.Flight)
               .HasForeignKey(r => r.FlightId);
        }
    }
}
