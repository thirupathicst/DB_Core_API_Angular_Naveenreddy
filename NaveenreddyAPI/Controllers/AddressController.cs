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
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressRepository _repository;
        public AddressController(ILogger<AddressController> logger, IAddressRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(B_Address address)
        {
            return Ok(await _repository.AddAddress(address));
        }

        [HttpPut]
        public async Task<IActionResult> Put(B_Address address)
        {
            return Ok(await _repository.UpdateAddress(address));
        }
    }
}
