using Application.Interfaces;
using Application.Services;
using Domain;
using Application.DTOs;
using Moq;
using Xunit;

namespace Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldCreateCustomer_WhenRequestIsValid()
        {
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            var request = new CustomerInfo
            {
                FirstName = "Ralph",
                LastName = "Del Socorro",
                Email = "ralph@email.com",
                PhoneNumber = "09976589185"
            };

            var result = await service.CreateAsync(request);

            Assert.NotNull(result);
            Assert.Equal("Ralph", result.FirstName);
            Assert.Equal("Del Socorro", result.LastName);
            Assert.Equal("ralph@email.com", result.Email);

            repositoryMock.Verify(x => x.AddAsync(It.IsAny<Customer>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenEmailIsInvalid()
        {
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            var request = new CustomerInfo
            {
                FirstName = "Ralph",
                LastName = "Del Socorro",
                Email = "asdf123",
                PhoneNumber = "09976589185"
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync(request));
        }

        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenFirstNameIsEmpty()
        {
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            var request = new CustomerInfo
            {
                FirstName = "",
                LastName = "Del Socorro",
                Email = "ralph@email.com",
                PhoneNumber = "09976589185"
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync(request));
        }
        [Fact]
        public async Task CreateAsync_ShouldThrowException_WhenLastNameIsEmpty()
        {
            var repositoryMock = new Mock<ICustomerRepository>();
            var service = new CustomerService(repositoryMock.Object);

            var request = new CustomerInfo
            {
                FirstName = "Ralph",
                LastName = "",
                Email = "ralph@email.com",
                PhoneNumber = "09976589185"
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync(request));
        }
    }
}