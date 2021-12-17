using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using BusinesEntites;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly ILogger<StoryController> _logger;
        private readonly IStoryRepository _repository;

        public StoryController(ILogger<StoryController> logger, IStoryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Story), 200)]
        public async Task<IActionResult> Post(B_Story story)
        {
            return Ok(await _repository.AddStory(story));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Story), 200)]
        public async Task<IActionResult> Put(B_Story story)
        {
            return Ok(await _repository.UpdateStory(story));
        }
    }
}
