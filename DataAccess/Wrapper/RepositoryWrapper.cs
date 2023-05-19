using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using DataAccess.Repositories;
using Domain.Wrapper;
using DataAccess.Models;
using Domain.Interfaces;


namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private magazContext _repoContext;
        private IUserRepository _user;
        private IBookingRepository _booking;
        private ICartRepository _cart;
        private ICartItemRepository _cartitem;
        private IDescriptionProductRepository _descriptionproduct;
        private IFilterRepository _filter;
        private IProductRepository _product;

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
        public IBookingRepository Booking {
            get {
                if (_booking == null) {
                    _booking = new FilterRepository(_repoContext);
                }
                return _booking;
            }
        }
        public ICartRepository Cart {
            get {
                if (_cart == null) {
                    _cart = new CartRepository(_repoContext);
                }
                return _cart;
            }
        }
        public ICartItemRepository CartItem {
            get {
                if (_cartitem == null) {
                    _cartitem = new CartItemRepository(_repoContext);
                }
                return _cartitem;
            }
        }
        public IDescriptionProductRepository DescriptionProduct {
            get {
                if (_descriptionproduct == null) {
                    _descriptionproduct = new DescriptionProductRepository(_repoContext);
                }
                return _descriptionproduct;
            }
        }
        public IFilterRepository Filter {
            get {
                if (_filter == null) {
                    _filter = new FilterrRepository(_repoContext);
                }
                return _filter;
            }
        }
        public IProductRepository Product {
            get {
                if (_product == null) {
                    _product = new ProductRepository(_repoContext);
                }
                return _product;
            }
        }
        public RepositoryWrapper(magazContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
