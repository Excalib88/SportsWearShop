using System.Linq;
using System.Threading.Tasks;
using SportsWearShop.Api.DataAccess;
using SportsWearShop.Api.DataAccess.Entities;
using SportsWearShop.Api.Domain.Identity.Models;

namespace SportsWearShop.Api.Domain.Identity.Services
{
    public class ProductService : IProductService
    {
        private readonly ApiDbContext _context;
        private readonly IFileService _fileService;

        public ProductService(ApiDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<long> Create(CreateProductDto request)
        {
            var entity = new ProductEntity
            {
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                NormalizedName = request.NormalizedName
            };

            var result = await _context.Products.AddAsync(entity);
            
            if (request.Files != null)
            {
                var filenames = await _fileService.BulkUpload(request.Files);

                if (filenames.Any())
                {
                    foreach (var filename in filenames)
                    {
                        await _context.Pictures.AddAsync(new PictureEntity
                        {
                            Filename = filename,
                            ProductId = result.Entity.Id
                        });
                    }
                }
            }

            if (request.CategoryId != null)
            {
                await _context.CategoryProducts.AddAsync(new CategoryProductEntity
                {
                    CategoryId = request.CategoryId,
                    ProductId = result.Entity.Id
                });
            }

            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}