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
    public class ProductServiceTest
    {
        private readonly ProductService service;
        private readonly Mock<IProductRepository> goodRepositoryMoq;

        public ProductServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            goodRepositoryMoq = new Mock<IProductRepository>();

            repositoryWrapperMoq.Setup(x => x.Product)
                .Returns(goodRepositoryMoq.Object);

            service = new ProductService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Product() },
                new object[] { new Product() { ProductId = 101 } },
                new object[] { new Product() { ProductId = 101, NameP = "Text" } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewUser_ShouldNot(Product product)
        {
            //arrange 
            var newUser = product;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            //arrange 
            var newUser = new Product() { Price = 5, ProductId = 101, NameP = "Text", CategoryId = 1};

            //act 
            await service.Create(newUser);

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Product>()), Times.Once);
        }
    }
}

