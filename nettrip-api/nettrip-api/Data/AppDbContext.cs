using Microsoft.EntityFrameworkCore;
using nettrip_api.Model;

namespace nettrip_api.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        public DbSet<User> users { get; set; }

        public DbSet<Model.Route> routes { get; set; }
        public DbSet<Bus> buses { get; set; }

        public DbSet<Trip> trips { get; set; }

        public DbSet<Seat> seats { get; set; }
        public DbSet<TripSeat> TripSeats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationSeat> ReservationSeats { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            //Bus           1 - *   Seat
            //Bus           1 - *   Trip
            //Route         1 - *   Trip
            //Trip          1 - *   TripSeat
            //Seat          1 - *   TripSeat
            //Reservation   1 - *   ReservationSeat
            //Reservation   1 - 1   Trip
            //Payment       1 - 1   Reservation


            //modelBuilder.Entity<Seat>()
            //    .HasOne(s => s.bus)
            //    .WithMany(b => b.Seats)
            //    .HasForeignKey(s => s.BusId);
        }


    }
}
