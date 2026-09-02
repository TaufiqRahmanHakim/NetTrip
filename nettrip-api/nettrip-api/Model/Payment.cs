namespace nettrip_api.Model {
    public class Payment {
        public Guid Id { get; set; }

        public Guid ReservationId { get; set; }

        public decimal Amount { get; set; }

        public string Method { get; set; } = "Mock";
        public string Status { get; set; } = "Pending";

        public DateTime PaidAt { get; set; }

        public Reservation Reservation { get; set; } = null!;
    }
}
