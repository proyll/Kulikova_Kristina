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
    public class FilterrRepository : RepositoryBase<Filterr>, IFilterRepository
    {
        public FilterrRepository(magazContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}





