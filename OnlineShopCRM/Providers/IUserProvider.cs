namespace OnlineShopCRM.Providers;

public interface IUserProvider
{
    public int UserId { get; }
    public string? Username { get; }
}
