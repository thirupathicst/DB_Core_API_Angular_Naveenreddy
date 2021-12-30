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
using Microsoft.Extensions.Caching.Memory;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ILoginRepository _repository;
        private readonly ITokenManager _tokenManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMemoryCache _cache;
        public AccountController(ILoginRepository repository, IMemoryCache cache, ITokenManager tokenManager, ILogger<AccountController> logger)
        {
            _repository = repository;
            _cache = cache;
            _tokenManager = tokenManager;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(Login login)
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
            status =await _repository.CreateAsync(_login, history);
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
                status.Message = TokenManager.GenerateToken(login.Emailid, status.PersonId);
                _cache.Set<int>($"PersonId-{status.PersonId}", status.PersonId, TimeSpan.FromMinutes(30));
                return Ok(status);
            }
            else if (B_UserStatus.Invalid == status.Status)
            {
                status.Message = "Invalid credentails or user not exsist";
                return BadRequest(status);
            }
            else
            {
                status.Message = "Currently not accepting user details";
                return BadRequest(status);
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(B_ChangePassword password)
        {
            password.PersonId = _tokenManager.GetUserId();
            if (password.NewPassword.Equals(password.ConfirmPassword))
            {
                return Ok(await _repository.ChangePassword(password));
            }
            else
            {
                ModelState.AddModelError("NewPassword", "NewPassword and ConfirmPassword should be same");
                return BadRequest(password);
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(B_ForgotPassword forgotPassword)
        {
            await _repository.ForgotPassword(forgotPassword);
            _cache.Set<string>(forgotPassword.EmailId, new Random().Next(0, 1000000).ToString("D6"), TimeSpan.FromMinutes(5));
            _logger.LogInformation(_cache.Get<string>(forgotPassword.EmailId));
            return Ok();
        }

        [HttpGet]
        [Route("OTPVerification")]
        [AllowAnonymous]
        public IActionResult OTPVerification(int OTP, string EmailId)
        {
            if (OTP ==int.Parse( _cache.Get<string>(EmailId)))
            {
                _cache.Remove(EmailId);
                return Ok();
            }
            else
            {
                return BadRequest("Invalid OTP");
            }
        }

        [HttpGet]
        [Route("Signout")]
        public IActionResult Signout()
        {
            _cache.Remove($"PersonId-{_tokenManager.GetUserId()}");
            return Ok();
        }
    }
}
