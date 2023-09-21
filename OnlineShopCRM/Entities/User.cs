namespace OnlineShopCRM.Entities;

//savdogar userlar
public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public string PasswordHash { get; set; }
    public required string PhoneNumber { get; set; }
    public List<Customer>? Customers { get; set; }
    public List<Order>? Orders { get; set; }
    public List<Product>? Products { get; set; }
}
