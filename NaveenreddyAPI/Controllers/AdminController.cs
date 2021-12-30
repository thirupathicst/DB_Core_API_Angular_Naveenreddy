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
    public class AdminController: ControllerBase
    {
        private readonly AdminRepository _admin;
        public AdminController(AdminRepository admin)
        {
            _admin=admin;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _admin.SelectAllAsync());
        }
    }
}