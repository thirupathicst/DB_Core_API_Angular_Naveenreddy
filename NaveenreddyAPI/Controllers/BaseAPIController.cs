using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        public int UserId => GetUserId();
        public string UserEmail => GetUserEmail();
        private readonly IHttpContextAccessor _user;
        public BaseAPIController(IHttpContextAccessor user)
        {
            _user = user;
        }

        private int GetUserId()
        {
            var claims = _user.HttpContext.User.Claims;
            return int.Parse(claims.Where(x => x.Type == ClaimTypes.Sid).FirstOrDefault()?.Value);
        }

        private string GetUserEmail()
        {
            var claims = _user.HttpContext.User.Claims;
            return claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault()?.Value;
        }
    }
}
