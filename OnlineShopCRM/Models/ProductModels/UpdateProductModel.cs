using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.ProductModels;

public class UpdateProductModel
{
    public long Price { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
