using Microsoft.EntityFrameworkCore;
using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Context;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<SaleProduct> SaleProducts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
