using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class UserClaims : ITokenManager
{
    private readonly IHttpContextAccessor _user;

    public UserClaims(IHttpContextAccessor user)
    {
        _user = user;
    }

    public int GetUserId()
    {
        var claims = _user.HttpContext.User.Claims;
        return int.Parse(claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault()?.Value);
    }

    public string GetUserEmail()
    {
        var claims = _user.HttpContext.User.Claims;
        return claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault()?.Value;
    }
}