namespace nettrip_api.Model {
    public class TripSeat {
        public Guid Id { get; set; }

        public Guid TripId { get; set; }
        public Guid SeatId { get; set; }

        public string Status { get; set; } = "Available";

        public Trip Trip { get; set; } = null!;
        public Seat Seat { get; set; } = null!;
    }
}
