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
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressRepository _repository;
        private readonly ITokenManager _tokenManager;
        public AddressController(ILogger<AddressController> logger, IAddressRepository repository, ITokenManager tokenManager)
        {
            _logger = logger;
            _repository = repository;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(B_Address), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.SelectByIdAsync(_tokenManager.GetUserId()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Address), 200)]
        public async Task<IActionResult> Post(B_Address address)
        {
            address.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.CreateAsync(address));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Address), 200)]
        public async Task<IActionResult> Put(B_Address address)
        {
            address.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateAsync(address));
        }
    }
}
