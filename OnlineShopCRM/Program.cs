using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Context;
using OnlineShopCRM.Extensions;
using OnlineShopCRM.Managers;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Providers;
using OnlineShopCRM.Repositories;
using OnlineShopCRM.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    options.UseInMemoryDatabase("MyDb");
    //options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
builder.Services.AddScoped<IInterestRepository, InterestRepository>();
builder.Services.AddScoped<IInterestManager, InterestManager>();
builder.Services.AddScoped<ITokenManager, JwtBearerTokenManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerProductRepository, CustomerProductRepository>();
builder.Services.AddScoped<IOrderProductManager, OrderProductManager>();
builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddJwt(builder.Configuration);
builder.Services.AddSwaggerGenJwt();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.MigrateAppDb();
