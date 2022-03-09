using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SearchController : ControllerBase
    {
        private readonly IPersonalInfoRepository _repository;
        public SearchController(IPersonalInfoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var dd = await _repository.SelectAllAsync(x => x.Name.Contains(name));
            return Ok(dd);
        }
    }
}