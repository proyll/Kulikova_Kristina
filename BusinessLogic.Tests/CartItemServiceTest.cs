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
    public class CartItemServiceTest
    {

        private readonly CartItemService service;
        private readonly Mock<ICartItemRepository> goodRepositoryMoq;

        public CartItemServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            goodRepositoryMoq = new Mock<ICartItemRepository>();

            repositoryWrapperMoq.Setup(x => x.CartItem)
                .Returns(goodRepositoryMoq.Object);

            service = new CartItemService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new CartItem() },
                new object[] { new CartItem() { CartId = 101 } },
                new object[] { new CartItem() { CartId = 101, Price = 123 } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<CartItem>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewUser_ShouldNot(CartItem product)
        {
            //arrange 
            var newUser = product;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<CartItem>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            //arrange 
            var newUser = new CartItem() { CartId = 101, Price = 123 };

            //act 
            await service.Create(newUser);

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<CartItem>()), Times.Once);
        }
    }
}
