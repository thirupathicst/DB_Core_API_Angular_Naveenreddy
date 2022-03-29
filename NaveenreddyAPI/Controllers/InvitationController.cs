
using System.Threading.Tasks;
using BusinesEntites;
using DBRepository.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationRepository _repository;
        private readonly ITokenManager _tokenManager;

        public InvitationController(IInvitationRepository repository, ITokenManager tokenManager)
        {
            _repository = repository;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(B_Invitation), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.SelectAllAsync(x => x.PersonId == _tokenManager.GetUserId()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Invitation), 200)]
        public async Task<IActionResult> Post(B_Invitation invitation)
        {
            invitation.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.CreateAsync(invitation));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Invitation), 200)]
        public async Task<IActionResult> Put(B_Invitation invitation)
        {
            invitation.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateAsync(invitation));
        }
    }
}