namespace OnlineShopCRM.Entities;

public class CustomerProduct
{
    public int Id { get; set; }
    public Product? Product { get; set; }
    public int ProductId { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }
}
