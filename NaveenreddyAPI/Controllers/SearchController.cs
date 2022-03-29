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
        public async Task<IActionResult> Get(string name, string city)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return Ok(await _repository.SelectAllAsync(x => x.Name.Contains(name)));
            }
            else if (!string.IsNullOrEmpty(city))
            {
                return Ok(await _repository.SelectAllAsync(x => x.Placeofbirth.Contains(city)));
            }
            else if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(name))
            {
                return Ok(await _repository.SelectAllAsync(x => x.Placeofbirth.Contains(city) && x.Name.Contains(name)));
            }
            else
            {
                return Ok(await _repository.SelectAllAsync());
            }
        }
    }
}