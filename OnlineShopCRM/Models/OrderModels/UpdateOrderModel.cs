using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.OrderModels;

public class UpdateOrderModel
{
    public bool IsActive { get; set; }
    public bool IsPay { get; set; }
    public bool IsCancel { get; set; }
    public long Residual { get; set; }
    public long Summary { get; set; }
    public required DateOnly OrderDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public required List<int> ProductsId { get; set; }
    public string? Description { get; set; }
}
