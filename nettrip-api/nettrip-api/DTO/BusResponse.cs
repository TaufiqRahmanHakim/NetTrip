namespace nettrip_api.DTO {
    public class BusResponse {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
