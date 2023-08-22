namespace OnlineShopCRM.Entities;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string PhoneNumber { get; set; }
    public List<Customer>? Customers { get; set; }
}
