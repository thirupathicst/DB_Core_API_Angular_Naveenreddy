using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DBRepository.Repository;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController:ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly AdminRepository _admin;
        public AdminController(ILogger<AdminController> logger,AdminRepository admin)
        {
            _logger=logger;
            _admin=admin;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _admin.SelectAll());
        }
    }
}