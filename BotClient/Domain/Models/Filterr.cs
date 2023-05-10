using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Filterr
    {
        public Filterr()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string SubcategoryName { get; set; } = null!;
        public int ProductId { get; set; }
        public string NameP { get; set; } = null!;
        public string Color { get; set; } = null!;
        public bool Popular { get; set; }
        public string Material { get; set; } = null!;
        public string Size { get; set; } = null!;
        public int Price { get; set; }
        public int Sale { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
