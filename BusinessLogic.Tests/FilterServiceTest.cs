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
    public class FilterServiceTest
    {
        private readonly FilterService service;
        private readonly Mock<IFilterRepository> goodRepositoryMoq;

        public FilterServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            goodRepositoryMoq = new Mock<IFilterRepository>();

            repositoryWrapperMoq.Setup(x => x.Filter)
                .Returns(goodRepositoryMoq.Object);

            service = new FilterService(repositoryWrapperMoq.Object);
        }
        public static IEnumerable<object[]> GetIncorrectCustomers()
        {
            return new List<object[]>
            {
                new object[] { new Filterr() },
                new object[] { new Filterr() { CategoryId = 101 } },
                new object[] { new Filterr() { CategoryId = 101, CategoryName = "Text" } }
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullExep()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Filterr>()), Times.Never);
        }
        [Theory]
        [MemberData(nameof(GetIncorrectCustomers))]
        public async Task CreateAsyncNewUser_ShouldNot(Filterr product)
        {
            //arrange 
            var newUser = product;

            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Filterr>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public async Task CreateAsyncNewUser_Should()
        {
            //arrange 
            var newUser = new Filterr() { Price = 5, CategoryId = 101, CategoryName = "Text", ProductId = 1 };

            //act 
            await service.Create(newUser);

            //assert
            goodRepositoryMoq.Verify(x => x.Create(It.IsAny<Filterr>()), Times.Once);
        }
    }
}
