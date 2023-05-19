using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class CartService : ICartService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CartService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Cart>> GetAll()
        {
            return await _repositoryWrapper.Cart.FindAll();
        }
        public async Task<Cart> GetById(int id)
        {
            var filter = await _repositoryWrapper.Cart
            .FindByCondition(x => x.CartId == id);
            return filter.First();
        }
        public async Task Create(Cart model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }


           
            await _repositoryWrapper.Cart.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Cart model)
        {
            await _repositoryWrapper.Cart.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var filter = await _repositoryWrapper.Cart
            .FindByCondition(x => x.CartId == id);
            await _repositoryWrapper.Cart.Delete(filter.First());
            await _repositoryWrapper.Save();
        }
    }
}
