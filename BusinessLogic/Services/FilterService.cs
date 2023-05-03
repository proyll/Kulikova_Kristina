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
    public class FilterService : IFilterService
    {
        IRepositoryWrapper _repositoryWrapper;
        public FilterService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Filterr>> GetAll()
        {
            return await _repositoryWrapper.Filter.FindAll();
        }
        public async Task<Filterr> GetById(int id)
        {
            var Filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.ProductId == id);
            return Filter.First();
        }
        public async Task Create(Filterr model)
        {
            await _repositoryWrapper.Filter.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Filterr model)
        {
            await _repositoryWrapper.Filter.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.ProductId == id);
            await _repositoryWrapper.Filter.Delete(Filter.First());
            await _repositoryWrapper.Save();
        }

    }
}
