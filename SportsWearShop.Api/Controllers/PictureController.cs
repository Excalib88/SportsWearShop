using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsWearShop.Api.DataAccess;
using SportsWearShop.Api.DataAccess.Entities;
using SportsWearShop.Api.Domain.Identity.Services;

namespace SportsWearShop.Api.Controllers
{
    [ApiController]
    [Route("picture")]
    public class PictureController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly ApiDbContext _context;

        public PictureController(IFileService fileService, ApiDbContext context)
        {
            _fileService = fileService;
            _context = context;
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
        
        [HttpPost("{productId:long}")]
        public async Task<IActionResult> AddPicturesToProduct(IFormFileCollection formFiles, long productId)
        {
            if (formFiles == null) return BadRequest();
            var filenames = await _fileService.BulkUpload(formFiles);

            if (!filenames.Any()) return Ok();
            
            foreach (var filename in filenames)
            {
                await _context.Pictures.AddAsync(new PictureEntity
                {
                    Filename = filename,
                    ProductId = productId
                });
            }

            return Ok();
        }
    }
}