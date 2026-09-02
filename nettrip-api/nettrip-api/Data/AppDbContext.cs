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
        public DbSet<Ticket> Tickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            // Bus -> Seat
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Bus)
                .WithMany(b => b.Seats)
                .HasForeignKey(s => s.BusId);

            // Bus -> Trip
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Bus)
                .WithMany()
                .HasForeignKey(t => t.BusId);

            // Route -> Trip
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Route)
                .WithMany(r => r.Trips)
                .HasForeignKey(t => t.RouteId);

            // Trip -> TripSeat
            modelBuilder.Entity<TripSeat>()
                .HasOne(ts => ts.Trip)
                .WithMany(t => t.TripSeats)
                .HasForeignKey(ts => ts.TripId);

            // Seat -> TripSeat
            modelBuilder.Entity<TripSeat>()
                .HasOne(ts => ts.Seat)
                .WithMany(s => s.TripSeats)
                .HasForeignKey(ts => ts.SeatId);

            // User -> Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            // Trip -> Reservation
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Trip)
                .WithMany()
                .HasForeignKey(r => r.TripId);

            // Reservation -> ReservationSeat
            modelBuilder.Entity<ReservationSeat>()
                .HasOne(rs => rs.Reservation)
                .WithMany(r => r.ReservationSeats)
                .HasForeignKey(rs => rs.ReservationId);

            // TripSeat -> ReservationSeat
            modelBuilder.Entity<ReservationSeat>()
                .HasOne(rs => rs.TripSeat)
                .WithMany()
                .HasForeignKey(rs => rs.TripSeatId);

            // Reservation -> Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation)
                .WithOne(r => r.Payment)
                .HasForeignKey<Payment>(p => p.ReservationId);

            // Reservation -> Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Reservation)
                .WithMany()
                .HasForeignKey(t => t.ReservationId);

            // TripSeat -> Ticket
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.TripSeat)
                .WithMany()
                .HasForeignKey(t => t.TripSeatId);

            
        }


    }
}
