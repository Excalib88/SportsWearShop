using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsWearShop.Api.Domain.Identity.Models;
using SportsWearShop.Api.Domain.Identity.Services;

namespace SportsWearShop.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto request)
        {
            var result = await _productService.Create(request);
            return Ok(new {id = result});
        }
    }
}