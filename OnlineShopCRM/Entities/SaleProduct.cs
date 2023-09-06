namespace OnlineShopCRM.Entities;

//sotilgan mahsulot
public class SaleProduct
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }
    public required DateOnly SaleDate { get; set; }
    public required long Price { get; set; }
}
