using OnlineShopCRM.Entities;

namespace OnlineShopCRM.Models;

public class CreateCustomerModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public required string PhoneNumber { get; set; }
}
