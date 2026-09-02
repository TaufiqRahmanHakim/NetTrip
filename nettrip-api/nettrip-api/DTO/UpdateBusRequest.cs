namespace nettrip_api.DTO {
    public class UpdateBusRequest {
        public string Name { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
    }
}
