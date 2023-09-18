namespace OnlineShopCRM.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public bool IsActive { get; set; }
    public bool IsPay { get; set; }
    public int Price { get; set; }
    public DateOnly OrderDate { get; set; }
    public 
}
