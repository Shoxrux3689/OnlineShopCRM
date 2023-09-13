namespace OnlineShopCRM.Models.UserModels;

public class CreateUserModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
    public required string PhoneNumber { get; set; }
}
