using AM.ApplicationCore.Domain;
using AM.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Data
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        public AMContext(DbContextOptions<AMContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=AGF-DESKTOP; 
                                          Database=Airport; 
                                          Integrated Security=True; 
                                          TrustServerCertificate=True");
                //.LogTo(Console.WriteLine);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FlightConfig());
            modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
            modelBuilder.ApplyConfiguration(new ReservationConfig());

            ConfigureConvention(modelBuilder);
        }

        private void ConfigureConvention(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetColumnType("date");
                    }
                }
            }
        }
    }
}
