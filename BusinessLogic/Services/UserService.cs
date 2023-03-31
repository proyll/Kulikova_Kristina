using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;
using DataAccess;

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
            await _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Userss model)
        {
            _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User
            .FindByCondition(x => x.Id == id);
            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }
    }
}
