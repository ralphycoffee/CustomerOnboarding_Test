using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> CreateAsync(CustomerInfo request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName)) throw new ArgumentException("First name is required.");
            if (string.IsNullOrWhiteSpace(request.LastName)) throw new ArgumentException("Last name is required.");
            if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains("@")) throw new ArgumentException("Valid email is required.");

            var customer = new Customer
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = request.Email.Trim(),
                PhoneNumber = request.PhoneNumber.Trim(),
                SignatureBase64 = request.SignatureBase64,
                DateCreated = DateTime.UtcNow
            };

            await _repository.AddAsync(customer);

            return customer;
        }

        public Task<Customer?> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }


        public Task<List<Customer>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
