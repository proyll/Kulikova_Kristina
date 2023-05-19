using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class FilterRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public FilterRepository(magazContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}

