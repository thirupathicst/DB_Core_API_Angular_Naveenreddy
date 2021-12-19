using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using BusinesEntites;
using NaveenreddyAPI.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ILoginRepository _repository;
        public AccountController(ILogger<AccountController> logger, ILoginRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            B_UserInfo status;
            B_Login _login = new B_Login()
            {
                Emailid = login.Emailid,
                Password = login.Password
            };
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var userAgent = Request.Headers["User-Agent"].ToString();
            B_LoginHistory history = new B_LoginHistory
            {
                Browsername = userAgent,
                IPaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                Logindatetime = DateTime.Now
            };
            status = _repository.AddLogin(_login, history);
            if (B_UserStatus.Invalid == status.Status)
            {
                status.Message = "Invalid credentails or user not exsist";
                return BadRequest(status);
            }
            else if (B_UserStatus.Inactive == status.Status)
            {
                status.Message = "Inactive user contact admin";
                return BadRequest(status);
            }
            else if (B_UserStatus.Active == status.Status)
            {
              status.Message=TokenManager.GenerateToken(login.Emailid);
                return Ok(status);
            }
            else
            {
                //return Ok(login);
                status.Message = "Currently not accepting user details";
                return BadRequest(status);
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(B_ChangePassword password)
        {
            if (password.NewPassword.Equals(password.ConfirmPassword))
            {
                await _repository.ChangePassword(password);
                return Ok();
            }
            else
            {
                ModelState.AddModelError("NewPassword", "NewPassword and ConfirmPassword should be same");
                return BadRequest(password);
            }
        }
    }
}
