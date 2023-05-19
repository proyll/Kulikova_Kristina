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
    public class BookingService : IBookingService
    {
        private IRepositoryWrapper _repositoryWrapper;
        public BookingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Booking>> GetAll()
        {
            return await _repositoryWrapper.Booking.FindAll();
        }
        public async Task<Booking> GetById(int id)
        {
            var filter = await _repositoryWrapper.Booking
            .FindByCondition(x => x.BookingId == id);
            return filter.First();
        }
        public async Task Create(Booking model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }


            if (string.IsNullOrEmpty(model.StatusB)) {
                throw new ArgumentException(nameof(model.StatusB));
            }
            if (string.IsNullOrEmpty(model.Delivery)) {
                throw new ArgumentException(nameof(model.Delivery));
            }
            if (string.IsNullOrEmpty(model.AddressB)) {
                throw new ArgumentException(nameof(model.AddressB));
            }
            await _repositoryWrapper.Booking.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Booking model)
        {
            await _repositoryWrapper.Booking.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var filter = await _repositoryWrapper.Booking
            .FindByCondition(x => x.BookingId == id);
            await _repositoryWrapper.Booking.Delete(filter.First());
            await _repositoryWrapper.Save();
        }
    }
}
