using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.SaleModels;

public class UpdateSale
{
    public required string Name { get; set; }
    public required DateOnly SaleDate { get; set; }
    public required long Price { get; set; }
}
