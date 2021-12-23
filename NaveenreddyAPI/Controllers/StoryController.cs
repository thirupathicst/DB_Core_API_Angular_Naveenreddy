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
    public class StoryController : NaveenReddyBaseController<StoryController>
    {
        private readonly IStoryRepository _repository;
        public StoryController(IStoryRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Story), 200)]
        public async Task<IActionResult> Post(B_Story story)
        {
            story.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.AddStory(story));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Story), 200)]
        public async Task<IActionResult> Put(B_Story story)
        {
            story.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateStory(story));
        }
    }
}
