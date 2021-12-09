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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginRepository _repository;
        public LoginController(ILogger<LoginController> logger, ILoginRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post(Login login)
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
                return Ok(status);
            }
            else if (B_UserStatus.Inactive == status.Status)
            {
                status.Message = "Inactive user contact admin";
                return Ok(status);
            }
            else if (B_UserStatus.Active == status.Status)
            {
                return Ok(status.PersonId);
            }
            else
            {
                //return Ok(login);
                status.Message = "Currently not accepting user details";
                return Ok(status);
            }
        }


    }
}
