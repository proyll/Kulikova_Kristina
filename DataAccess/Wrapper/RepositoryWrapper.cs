using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private OdezdaContext _repoContext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(OdezdaContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
