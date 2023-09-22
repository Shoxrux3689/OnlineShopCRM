using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Filters;

public class OrderFilter
{
    public string? ProductName { get; set; }
    public string? CustomerPhoneNumber { get; set; }
    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }
    public long? FromPrice { get; set; }
    public long? ToPrice { get; set; }
}
