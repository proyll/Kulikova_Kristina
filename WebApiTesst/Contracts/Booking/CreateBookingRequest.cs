namespace WebApiTesst.Contracts.Booking
{
    public class CreateBookingRequest
    {
        public int CartId { get; set; }
        public int Price { get; set; }
        public string? StatusB { get; set; }
        public string Delivery { get; set; } = null!;
        public string AddressB { get; set; } = null!;
    }
}
