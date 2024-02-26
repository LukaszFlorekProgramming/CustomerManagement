using CustomerManagementAPI.Data;
using CustomerManagementAPI.Mapping;
using CustomerManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CustomerManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDbConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCustomerManagement", builder =>
    {
        builder.WithOrigins("https://localhost:7151")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowCustomerManagement");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
