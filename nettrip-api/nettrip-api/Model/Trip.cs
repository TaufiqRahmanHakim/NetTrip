namespace nettrip_api.Model {
    public class Trip {
        public Guid Id { get; set; }
        public Guid BusId { get; set; }
        public Guid RouteId { get; set; }
        public DateTime DepartureAt { get; set; }
        public DateTime ArrivalAt { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = "Scheduled";

        public Route Route { get; set; } = null!;
        public Bus Bus { get; set; } = null!;
    }
}
