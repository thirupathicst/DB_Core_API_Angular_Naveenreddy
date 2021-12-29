using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using BusinesEntites;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReligiousController : ControllerBase
    {
        private readonly IReligiousRepository _repository;
        private readonly ITokenManager _tokenManager;
        private readonly ILogger<FamilyController> _logger;
        public ReligiousController(IReligiousRepository repository, ILogger<FamilyController> logger, ITokenManager tokenManager)
        {
            _repository = repository;
            _logger = logger;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Religious), 200)]
        public async Task<IActionResult> Post(B_Religious religious)
        {
            religious.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.CreateAsync(religious));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Religious), 200)]
        public async Task<IActionResult> Put(B_Religious religious)
        {
            religious.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateAsync(religious));
        }
    }
}
