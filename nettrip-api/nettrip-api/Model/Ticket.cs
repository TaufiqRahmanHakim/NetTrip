namespace nettrip_api.Model {
    public class Ticket {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public Guid TripSeatId { get; set; }

        public string TicketNumber { get; set; } = string.Empty;
        public string Status { get; set; } = "Issued";

        public Reservation Reservation { get; set; } = null!;
        public TripSeat TripSeat { get; set; } = null!;
    }
}
