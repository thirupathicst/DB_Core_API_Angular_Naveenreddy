using DBRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesEntites;
using DBRepository.Repository.Interfaces;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly ILogger<EducationController> _logger;
        private readonly IEducationRepository _repository;
        public EducationController(ILogger<EducationController> logger, IEducationRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(B_Education educationdetails)
        {
            return Ok(await _repository.AddEducationDetails(educationdetails));
        }

        [HttpPut]
        public async Task<IActionResult> Put(B_Education educationdetails)
        {
            return Ok(await _repository.UpdateEducationDetails(educationdetails));
        }
    }
}
