using CustomerManagementUI.Models;

namespace CustomerManagementUI.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetCustomers();
        Task<CustomerDto> GetCustomerById(int id);
        Task<CustomerDto> CreateCustomer(CreateCustomerDto customer);
        Task<bool> UpdateCustomer(int customerId, UpdateCustomerDto updataCustomerDto);
        Task<bool> DeleteCustomer(int customerId);
    }
}
