﻿using Microsoft.AspNetCore.Http;
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
    public class ReligiousController : ControllerBase
    {
        private readonly ILogger<ReligiousController> _logger;
        private readonly IReligiousRepository _repository;
        private readonly ITokenManager _tokenManager;
        public ReligiousController(ILogger<ReligiousController> logger, IReligiousRepository repository, ITokenManager tokenManager)
        {
            _logger = logger;
            _repository = repository;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Religious), 200)]
        public async Task<IActionResult> Post(B_Religious religious)
        {
            religious.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.AddReligious(religious));
        }

        [HttpPut]
        [ProducesResponseType(typeof(B_Religious), 200)]
        public async Task<IActionResult> Put(B_Religious religious)
        {
            religious.PersonId = _tokenManager.GetUserId();
            return Ok(await _repository.UpdateReligious(religious));
        }
    }
}
