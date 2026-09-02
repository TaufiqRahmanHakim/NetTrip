namespace nettrip_api.Model {
    public class Reservation {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public Guid TripId { get; set; }

        public DateTime ExpiresAt { get; set; }
        public string Status { get; set; } = "Pending";

        public User User { get; set; } = null!;
        public Trip Trip { get; set; } = null!;

        public ICollection<ReservationSeat> ReservationSeats { get; set; }
            = new List<ReservationSeat>();

        public Payment Payment { get; set; } = null!;

    }
}
