using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementAPI.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(c => c.Address)
                .HasMaxLength(250);
            builder.Property(c => c.NIP)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
