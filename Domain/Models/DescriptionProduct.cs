using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class DescriptionProduct
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string? TextD { get; set; }
        public int Rating { get; set; }

        public virtual Userss Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
