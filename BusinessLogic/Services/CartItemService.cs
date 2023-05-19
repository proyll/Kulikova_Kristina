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
    public class CartItemService : ICartItemService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public CartItemService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<CartItem>> GetAll()
        {
            return await _repositoryWrapper.CartItem.FindAll();
        }
        public async Task<CartItem> GetById(int id)
        {
            var filter = await _repositoryWrapper.CartItem
            .FindByCondition(x => x.CartId == id);
            return filter.First();
        }
        public async Task Create(CartItem model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            await _repositoryWrapper.CartItem.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(CartItem model)
        {
            await _repositoryWrapper.CartItem.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var filter = await _repositoryWrapper.CartItem
            .FindByCondition(x => x.CartId == id);
            await _repositoryWrapper.CartItem.Delete(filter.First());
            await _repositoryWrapper.Save();
        }
    }
}
