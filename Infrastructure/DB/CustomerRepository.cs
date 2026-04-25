using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public Task<Customer?> GetByIdAsync(Guid id)
        {
            return _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return _context.Customers.ToListAsync();
        }
    }
}
