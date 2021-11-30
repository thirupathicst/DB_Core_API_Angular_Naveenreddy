using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using BusinesEntites;

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
        public async Task<IActionResult> Post(B_Login login)
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var userAgent = Request.Headers["User-Agent"].ToString();
            B_LoginHistory history = new B_LoginHistory
            {
                Browsername =userAgent,
                IPaddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                Logindatetime = DateTime.Now
            };
            await _repository.AddLogin(login,history);
            return Ok();
        }

    }
}
