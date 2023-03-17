using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<List<Userss>> GetAll();
        Task<Userss> GetById(int id);
        Task Create(Userss model);
        Task Update(Userss model);
        Task Delete(int id);
    }
}
