using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using BusinesEntites;
using Microsoft.AspNetCore.Authorization;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoryController : ControllerBase
    {
        private readonly IStoryRepository _repository;
        private readonly ITokenManager _tokenManager;
        private readonly ILogger<FamilyController> _logger;
        public StoryController(IStoryRepository repository, ILogger<FamilyController> logger, ITokenManager tokenManager)
        {
            _repository = repository;
            _logger = logger;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(B_Story), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.SelectByIdAsync(_tokenManager.GetUserId()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Story), 200)]
        public async Task<IActionResult> Post(B_Story story)
        {
            story.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.CreateAsync(story));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Story), 200)]
        public async Task<IActionResult> Put(B_Story story)
        {
            story.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateAsync(story));
        }

    }
}
