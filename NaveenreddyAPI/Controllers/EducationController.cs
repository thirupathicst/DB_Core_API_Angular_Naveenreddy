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
using Microsoft.AspNetCore.Authorization;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EducationController : NaveenReddyBaseController<EducationController>
    {
        private readonly IEducationRepository _repository;
        public EducationController(IEducationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Education), 200)]
        public async Task<IActionResult> Post(B_Education educationdetails)
        {
            educationdetails.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.AddEducationDetails(educationdetails));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Education), 200)]
        public async Task<IActionResult> Put(B_Education educationdetails)
        {
            educationdetails.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateEducationDetails(educationdetails));
        }
    }
}
