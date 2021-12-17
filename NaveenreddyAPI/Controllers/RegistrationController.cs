using BusinesEntites;
using DBRepository;
using DBRepository.Repository;
using DBRepository.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NaveenreddyAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IPersonalInfoRepository _repository;
        public RegistrationController(ILogger<RegistrationController> logger, IPersonalInfoRepository repository)
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
        [ProducesResponseType(typeof(B_PersonalInfo), 200)]
        public async Task<IActionResult> Post(B_Registration registration)
        {
            return Ok(await _repository.AddRegistration(registration));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_PersonalInfo), 200)]
        public async Task<IActionResult> Put(B_PersonalInfo personalinfo)
        {
            return Ok(await _repository.AddBioData(personalinfo));
        }
    }
}
