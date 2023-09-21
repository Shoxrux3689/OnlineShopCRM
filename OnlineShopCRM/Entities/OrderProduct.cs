namespace OnlineShopCRM.Entities;

public class OrderProduct
{
    public int Id { get; set; }
    public Order? Order { get; set; }
    public int OrderId { get; set; }
    public Product? Product { get; set; }
    public int ProductId { get; set; }
}
