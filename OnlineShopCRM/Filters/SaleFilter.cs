using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Filters;

public class SaleFilter
{
    public string? Name { get; set; }
    public string? CustomerPhoneNumber { get; set; }
    public DateOnly? FromSaleDate { get; set; }
    public DateOnly? ToSaleDate { get; set; }
    public long? FromPrice { get; set; }
    public long? ToPrice { get; set; }
}
