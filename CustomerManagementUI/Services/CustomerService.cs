using CustomerManagementUI.Models;
using System.Net.Http.Json;

namespace CustomerManagementUI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<CustomerDto>> GetCustomers()
        {
            var apiUrl = "api/Customer";
            return await _httpClient.GetFromJsonAsync<List<CustomerDto>>(apiUrl);
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            var apiUrl = $"api/Customer/{id}";
            return await _httpClient.GetFromJsonAsync<CustomerDto>(apiUrl);
        }

        public async Task<CustomerDto> CreateCustomer(CreateCustomerDto customer)
        {
            var apiUrl = "api/Customer";
            var response = await _httpClient.PostAsJsonAsync(apiUrl, customer);
            return await response.Content.ReadFromJsonAsync<CustomerDto>();
        }

        public async Task<bool> UpdateCustomer(int customerId, UpdateCustomerDto updataCustomerDto)
        {
            var apiUrl = $"api/Customer/{customerId}";
            var response = await _httpClient.PutAsJsonAsync(apiUrl, updataCustomerDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var apiUrl = $"api/Customer/{customerId}";
            var response = await _httpClient.DeleteAsync(apiUrl);
            return response.IsSuccessStatusCode;
        }
    }
}
