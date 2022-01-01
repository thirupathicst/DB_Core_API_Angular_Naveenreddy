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
           var _img= await _repository.SelectAllAsync(x=>x.PersonId== _tokenManager.GetUserId());
            return Ok(_img);
        }

        [HttpPost]
        [ProducesResponseType(typeof(B_Images), 200)]
        public async Task<IActionResult> Post(IFormFile[] file)
        {
            B_Images image = new B_Images();
            CreaateImageDirectory($"{env.WebRootPath}\\Images");
            foreach (var item in file)
            {
                image.ShortPath = $"Images\\{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";
                image.PhysicalPath = Path.Combine(env.WebRootPath, image.ShortPath);
                using (var stream = new FileStream(image.PhysicalPath, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                image.PersonId=_tokenManager.GetUserId();
                await _repository.CreateAsync(image);
            }
            return Ok(image);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {

            var _files = await _repository.GetSingleAsync(x => x.PersonId == _tokenManager.GetUserId() && x.ImageId == Id);
            new FileInfo(_files.Physicalpath).Delete();
            _logger.LogInformation($"file deleted: {_files.Physicalpath}");
            return NoContent();
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
