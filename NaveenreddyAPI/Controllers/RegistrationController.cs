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
    [Authorize]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IPersonalInfoRepository _repository;
        private readonly ITokenManager _tokenManager;
        public RegistrationController(ILogger<RegistrationController> logger, IPersonalInfoRepository repository, ITokenManager tokenManager)
        {
            _logger = logger;
            _repository = repository;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(B_PersonalInfo), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetRegistration(_tokenManager.GetUserId()));
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(B_PersonalInfo), 200)]
        public async Task<IActionResult> Post(B_Registration registration)
        {
            registration.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.AddRegistration(registration));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_PersonalInfo), 200)]
        public async Task<IActionResult> Put(B_PersonalInfo personalinfo)
        {
            personalinfo.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.AddBioData(personalinfo));
        }
    }
}
