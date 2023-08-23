using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.SaleProductModels;

public class CreateSaleProduct
{
    public required string Name { get; set; }
    public int CustomerId { get; set; }
    public required DateOnly SaleDate { get; set; }
    public required long Price { get; set; }
}
