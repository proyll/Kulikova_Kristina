using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Moq;
using Xunit;

namespace BusinessLogic.Tests
{
    public class CartServiceTest
    {
        private readonly CartService service;
        private readonly Mock<ICartRepository> goodRepositoryMoq;

        public CartServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            goodRepositoryMoq = new Mock<ICartRepository>();

            repositoryWrapperMoq.Setup(x => x.Cart)
                .Returns(goodRepositoryMoq.Object);

            service = new CartService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Cart() },
                new object[] { new Cart() { CartId = 101 } },
                new object[] { new Cart() { CartId = 101, CustomerId = 123 } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Cart>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewUser_ShouldNot(Cart product)
        {
            //arrange 
            var newUser = product;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Cart>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            //arrange 
            var newUser = new Cart() { CartId = 101, CustomerId = 123 };

            //act 
            await service.Create(newUser);

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Cart>()), Times.Once);
        }
    }
}
