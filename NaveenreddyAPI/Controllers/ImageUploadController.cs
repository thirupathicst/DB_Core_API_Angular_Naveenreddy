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

namespace NaveenreddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly ILogger<ImageUploadController> _logger;
        private readonly IImageRepository _repository;
        readonly IWebHostEnvironment env;

        public ImageUploadController(IWebHostEnvironment _env, ILogger<ImageUploadController> logger, IImageRepository repository)
        {
            env = _env;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            B_Images image = new B_Images();
            string fName = file.FileName;
            image.PhysicalPath = Path.Combine(env.WebRootPath, "Images\\" + Guid.NewGuid() + Path.GetExtension(file.FileName));
            using (var stream = new FileStream(image.PhysicalPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            image.ShortPath = $"~\\wwwroot\\Images\\{Guid.NewGuid()}.{Path.GetExtension(file.FileName)}";
            await _repository.AddImage(image);
            return Ok(image);
        }
    }
}
