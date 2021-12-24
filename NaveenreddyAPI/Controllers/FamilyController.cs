using BusinesEntites;
using DBRepository.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyRepository _repository;
        private readonly ITokenManager _tokenManager;
        private readonly ILogger<FamilyController> _logger;
        public FamilyController(IFamilyRepository repository, ILogger<FamilyController> logger, ITokenManager tokenManager)
        {
            _repository = repository;
            _logger = logger;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Family),200)]
        public async Task<IActionResult> Post(B_Family family)
        {
            family.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.AddFamilyDetails(family));
        }

        [HttpPut]
        public async Task<IActionResult> Put(B_Family family)
        {
            family.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateFamilyDetails(family));
        }
    }
}
