using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configurations
{
    public class PassengerConfig : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, fullName =>
            {
                fullName.Property(fn => fn.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("Name")
                    .IsRequired();

                fullName.Property(fn => fn.LastName)
                    .IsRequired();
            });

            builder.ToTable("Passengers");

            builder.HasDiscriminator<int>("îsTraveller")
                   .HasValue<Traveller>(1)
                   .HasValue<Staff>(2)
                   .HasValue<Passenger>(0);
        }
    }

    public class TravellerConfig : IEntityTypeConfiguration<Traveller>
    {
        public void Configure(EntityTypeBuilder<Traveller> builder)
        {
            //builder.ToTable("Travellers");

        }
    }

    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            //builder.ToTable("Staff");
        }
    }
}
