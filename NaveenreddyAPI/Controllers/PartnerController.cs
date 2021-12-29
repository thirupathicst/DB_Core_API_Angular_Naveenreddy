using DBRepository.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinesEntites;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartnerController : ControllerBase
    {
        private readonly ITokenManager _tokenManager;
        private readonly ILogger<PartnerController> _logger;
        private readonly IPartnerRepository _repository;
        public PartnerController(IPartnerRepository repository, ITokenManager tokenManager, ILogger<PartnerController> logger)
        {
            _logger = logger;
            _tokenManager = tokenManager;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(B_Partner), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetPartner(_tokenManager.GetUserId()));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Partner), 200)]
        public async Task<IActionResult> Put(B_Partner partner)
        {
            partner.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.CreateAsync(partner));
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Partner), 200)]
        public async Task<IActionResult> Post(B_Partner partner)
        {
            partner.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.CreateAsync(partner));
        }
    }
}