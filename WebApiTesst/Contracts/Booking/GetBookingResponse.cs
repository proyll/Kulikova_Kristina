namespace WebApiTesst.Contracts.Booking
{
    public class GetBookingResponse
    {
        public int BookingId { get; set; }
        public int CartId { get; set; }
        public int Price { get; set; }
        public string? StatusB { get; set; }
        public string Delivery { get; set; } = null!;
        public string AddressB { get; set; } = null!;
    }
}
