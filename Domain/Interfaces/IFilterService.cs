using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IFilterService
    {
        Task<List<Filterr>> GetAll();
        Task<Filterr> GetById(int id);
        Task Create(Filterr model);
        Task Update(Filterr model);
        Task Delete(int id);
    }
}
