using System.Security.Claims;

namespace OnlineShopCRM.Providers;

public class UserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserProvider(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public int UserId { get
        {
            if (_contextAccessor.HttpContext is null)
            {
                throw new InvalidOperationException("HttpContext cannot be null");
            }

            var userId = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
            {
                throw new InvalidOperationException("Value of claim is not be null");
            }

            return Convert.ToInt32(userId);
        }
    }

    public string? Username => _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
}
