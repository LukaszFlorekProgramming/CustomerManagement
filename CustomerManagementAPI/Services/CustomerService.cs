using AutoMapper;
using CustomerManagementAPI.Data;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerService(CustomerManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdCustomerAsync(int id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task<int> AddCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null) return false;
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDto updateCustomerDto)
        {
            var customer = _dbContext
                            .Customers
                            .FirstOrDefault(x => x.Id == id);

            if(customer == null) return false;

            customer.Name = updateCustomerDto.Name;
            customer.Address = updateCustomerDto.Address;
            customer.NIP = updateCustomerDto.NIP;

            _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
