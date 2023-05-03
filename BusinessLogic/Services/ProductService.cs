﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        IRepositoryWrapper _repositoryWrapper;
        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _repositoryWrapper.Product.FindAll();
        }
        public async Task<Product> GetById(int id)
        {
            var good = await _repositoryWrapper.Product.FindByCondition(x => x.ProductId == id);
            return good.First();
        }
        public async Task Create(Product model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.NameP)) {
                throw new ArgumentException(nameof(model.NameP));
            }

            if (model.CategoryId == 0) {
                throw new ArgumentException(nameof(model.CategoryId));
            }

            if (model.Price == 0) {
                throw new ArgumentException(nameof(model.Price));
            }

            await _repositoryWrapper.Product.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Product model)
        {
            await _repositoryWrapper.Product.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var customer = await _repositoryWrapper.Product
            .FindByCondition(x => x.ProductId == id);
            await _repositoryWrapper.Product.Delete(customer.First());
            await _repositoryWrapper.Save();
        }
    }
}

