using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.Data.Configurations
{
    public class PlaneConfig : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            builder.ToTable("MyPlanes");

            builder.HasKey(p => p.PlaneId);

            builder.Property(p => p.Capacity)
                   .HasColumnName("PlaneCapacity");
        }
    }
}
