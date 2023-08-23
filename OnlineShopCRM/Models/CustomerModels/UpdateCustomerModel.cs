namespace OnlineShopCRM.Models.CustomerModels;

public class UpdateCustomerModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Address { get; set; }
    public required string PhoneNumber { get; set; }
}
