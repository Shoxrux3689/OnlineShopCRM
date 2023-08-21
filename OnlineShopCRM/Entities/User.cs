namespace OnlineShopCRM.Entities;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public List<Customer>? Customers { get; set; }
}
