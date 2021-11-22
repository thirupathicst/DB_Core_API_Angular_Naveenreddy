using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using BusinesEntites;

using Microsoft.Extensions.Logging;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReligiousController : ControllerBase
    {
        private readonly ILogger<ReligiousController> _logger;
        private readonly IReligiousRepository _repository;
        public ReligiousController(ILogger<ReligiousController> logger, IReligiousRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(B_Religious religious)
        {
            return Ok(await _repository.AddReligious(religious));
        }

        [HttpPut]
        public async Task<IActionResult> Put(B_Religious religious)
        {
            return Ok(await _repository.UpdateReligious(religious));
        }
    }
}
