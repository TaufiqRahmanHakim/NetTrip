namespace nettrip_api.Model {
    public class Seat {
        public Guid Id { get; set; }
        public Guid BusId { get; set; }

        public string SeatNumber { get; set; } = string.Empty;
        public string SeatType { get; set; } = "Regular";

        public Bus Bus { get; set; } = null!;

        public ICollection<TripSeat> TripSeats { get; set; } = new List<TripSeat>();
    }
}
