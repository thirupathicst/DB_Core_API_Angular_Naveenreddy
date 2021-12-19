using Microsoft.AspNetCore.Http;
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
    public class ProfessionalController : ControllerBase
    {
        private readonly ILogger<ProfessionalController> _logger;
        private readonly IProfessionalRepository _repository;
        public ProfessionalController(ILogger<ProfessionalController> logger, IProfessionalRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Professional), 200)]
        public async Task<IActionResult> Post(B_Professional professional)
        {
            return Ok(await _repository.AddProfessional(professional));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Professional), 200)]
        public async Task<IActionResult> Put(B_Professional professional)
        {
            return Ok(await _repository.UpdateProfessional(professional));
        }
    }
}
