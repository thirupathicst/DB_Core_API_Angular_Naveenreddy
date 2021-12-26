using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repository.Interfaces;
using BusinesEntites;
using Microsoft.AspNetCore.Authorization;
using NaveenreddyAPI.Utilities;

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageUploadController : ControllerBase
    {
        private readonly IImageRepository _repository;
        private readonly IWebHostEnvironment env;
        private readonly ITokenManager _tokenManager;
        private readonly ILogger<FamilyController> _logger;
        public ImageUploadController(IImageRepository repository,IWebHostEnvironment _env, ILogger<FamilyController> logger, ITokenManager tokenManager)
        {
            env = _env;
            _repository = repository;
            _logger = logger;
            _tokenManager = tokenManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(B_Images[]), 200)]
        public async Task<IActionResult> Get()
        {
           // B_Images[] image;
           var _img= await _repository.SelectById(_tokenManager.GetUserId());
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Images), 200)]
        public async Task<IActionResult> Post(IFormFile[] file)
        {
            B_Images image = new B_Images();
            CreaateImageDirectory($"{env.WebRootPath}\\Images");
            foreach (var item in file)
            {
                string _locafile = $"Images\\{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";
                image.PhysicalPath = Path.Combine(env.WebRootPath, _locafile);
                using (var stream = new FileStream(image.PhysicalPath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                image.ShortPath = $"~\\wwwroot\\{_locafile}";
                image.PersonId=_tokenManager.GetUserId();
                await _repository.AddImage(image);
            }
            return Ok(image);
        }

        private bool CreaateImageDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return true;
        }
    }
}
