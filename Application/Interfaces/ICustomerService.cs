using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(CustomerInfo request);

        Task<Customer?> GetByIdAsync(Guid id);

        Task<List<Customer>> GetAllAsync();
    }
}
