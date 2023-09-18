using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.OrderModels;

public class CreateOrder
{
    public required string Name { get; set; }
    public int CustomerId { get; set; }
    public required DateOnly SaleDate { get; set; }
    public required long Price { get; set; }
}
