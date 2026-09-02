namespace nettrip_api.Model {
    public class ReservationSeat {
        public Guid Id { get; set; }

        public Guid ReservationId { get; set; }
        public Guid TripSeatId { get; set; }

        public Reservation Reservation { get; set; } = null!;
        public TripSeat TripSeat { get; set; } = null!;
    }
}
