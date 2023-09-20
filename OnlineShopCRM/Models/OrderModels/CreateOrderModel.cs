using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models.OrderModels;

public class CreateOrderModel
{
    public bool IsActive { get; set; }
    public bool IsPay { get; set; }
    public bool IsCancel { get; set; }
    public long Residual { get; set; }
    public required DateOnly OrderDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public string? Description { get; set; }
}
