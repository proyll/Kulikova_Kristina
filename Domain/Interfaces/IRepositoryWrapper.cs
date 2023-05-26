using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        Task Save();
        IBookingRepository Booking { get; }
        

        IFilterrRepository Filterr { get; }
        

        IDescriptionProductRepository DescriptionProduct { get; }
        

        IProductRepository Product { get; }
        

        ICartRepository Cart { get; }

        ICartItemRepository CartItem { get; }







    }
}
