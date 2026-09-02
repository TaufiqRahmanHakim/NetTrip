namespace nettrip_api.Model {
    public class Route {
        public Guid Id { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public int EstimatedMinutes { get; set; }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
