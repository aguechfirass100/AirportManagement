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
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => new { r.FlightId, r.PassengerId });

            builder.Property(r => r.Price).HasColumnType("decimal(18,2)");
            builder.Property(r => r.Seat).HasMaxLength(10);
            builder.Property(r => r.VIP).HasDefaultValue(false);

            builder.ToTable("Reservations");
        }
    }

}
