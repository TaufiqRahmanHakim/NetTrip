namespace nettrip_api.Model {
    public class Bus {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public string Status { get; set; } = "Active";

        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
