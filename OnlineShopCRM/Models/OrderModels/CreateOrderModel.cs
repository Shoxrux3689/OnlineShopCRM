using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.OrderModels;

public class CreateOrderModel
{
    public bool IsActive { get; set; }
    public bool IsPay { get; set; }
    public bool IsCancel { get; set; }
    public long Residual { get; set; }
    public long Summary { get; set; }
    public required DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string? Description { get; set; }
    public required List<int> ProductsId { get; set; }
}
