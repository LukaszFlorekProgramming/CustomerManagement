using CustomerManagementAPI.Models;

namespace CustomerManagementAPI.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetByIdCustomerAsync(int id);
        Task<int> AddCustomerAsync(CreateCustomerDto customer);
        Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDto customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
