using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SportsWearShop.Api.Domain.Identity.Services;

namespace SportsWearShop.Api.Controllers
{
    [ApiController]
    [Route("picture")]
    public class PictureController : ControllerBase
    {
        private readonly IFileService _fileService;

        public PictureController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> Get(string filename)
        {
            var result = await _fileService.Download(filename);   

            // var filePath2 = Path.Combine(_configuration["BasePicturePath"], "123.png");
            // await using var fs2 = System.IO.File.Create(filePath2);
            // await fs2.WriteAsync(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile formFile)
        {
            var result = await _fileService.Upload(formFile);

            return Ok(new {result});
        }
    }
}