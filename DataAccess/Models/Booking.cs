using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int CartId { get; set; }
        public int? Price { get; set; }
        public string StatusB { get; set; } = null!;
        public string Delivery { get; set; } = null!;
        public string AddressB { get; set; } = null!;

        public virtual Cart Cart { get; set; } = null!;
    }
}
