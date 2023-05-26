
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;


namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<Userss>
    {
        public Task<Userss?> GetByEmailAndPassword(string email, string password);
    }
}
