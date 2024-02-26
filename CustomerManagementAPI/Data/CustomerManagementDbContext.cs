using CustomerManagementAPI.Data.Configuration;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Data
{
    public class CustomerManagementDbContext : DbContext
    {
        public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options) : base(options) { }  
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
