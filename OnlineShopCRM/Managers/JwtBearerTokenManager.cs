using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShopCRM.Entities;
using OnlineShopCRM.Managers.Interfaces;
using OnlineShopCRM.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineShopCRM.Managers;

public class JwtBearerTokenManager : ITokenManager
{
    private readonly JwtOption _jwtOption;

    public JwtBearerTokenManager(IOptions<JwtOption> jwtOption)
    {
        _jwtOption = jwtOption.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

        var signingKey = System.Text.Encoding.UTF32.GetBytes(_jwtOption.SigningKey);
        var security = new JwtSecurityToken(
            issuer: _jwtOption.ValidIssuer,
            audience: _jwtOption.ValidAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_jwtOption.ExpiresInDays),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
            );

        var token = new JwtSecurityTokenHandler().WriteToken(security);
        return token;
    }
}
