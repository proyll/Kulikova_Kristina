using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using System.Data.SqlTypes;
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
        public async Task<List<Userss>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }
        public async Task<Userss> GetById(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.Id == id);
            return user.First();
        }
        public async Task Create(Userss model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }


            if (string.IsNullOrEmpty(model.FirstName)) {
                throw new ArgumentException(nameof(model.FirstName));
            }
            await _repositoryWrapper.User.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Userss model)
        {
            await _repositoryWrapper.User.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.Id == id);
            await _repositoryWrapper.User.Delete(user.First());
            await _repositoryWrapper.Save();
        }


    }
}

