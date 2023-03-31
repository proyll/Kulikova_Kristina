using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Userss
    {
        public Userss()
        {
            Carts = new HashSet<Cart>();
            DescriptionProducts = new HashSet<DescriptionProduct>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? UserEmail { get; set; }
        public string UserRole { get; set; } = null!;
        public string UserPassord { get; set; } = null!;

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<DescriptionProduct> DescriptionProducts { get; set; }
    }
}
