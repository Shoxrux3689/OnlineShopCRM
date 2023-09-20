namespace OnlineShopCRM.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public bool IsActive { get; set; }
    public bool IsPay { get; set; }
    public bool IsCancel { get; set; }
    public long Residual { get; set; }
    public required DateOnly OrderDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public Product? Product { get; set; }
    public int ProductId { get; set; }
    public string? Description { get; set; }
}
