using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<Userss>> GetAll()
        {
            return _repositoryWrapper.User.FindAll().ToListAsync();
        }
        public Task<Userss> GetById(int id)
        {
            var user = _repositoryWrapper.User
            .FindByCondition(x => x.Id == id).First();
            return Task.FromResult(user);
        }
        public Task Create(Userss model)
        {
            _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Userss model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var user = _repositoryWrapper.User
            .FindByCondition(x => x.Id == id).First();
            _repositoryWrapper.User.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

    }
}
