using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Interfaces;

namespace DataAccess
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        Task Save();
    }
}
