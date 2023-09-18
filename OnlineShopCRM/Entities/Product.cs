namespace OnlineShopCRM.Entities;

public class Product
{
    public int Id { get; set; }
    public required long Price { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public User? User { get; set; }
    public int UserId { get; set; }
}
