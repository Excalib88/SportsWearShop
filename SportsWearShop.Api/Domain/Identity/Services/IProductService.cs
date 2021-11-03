using System.Threading.Tasks;
using SportsWearShop.Api.DataAccess.Entities;
using SportsWearShop.Api.Domain.Identity.Models;

namespace SportsWearShop.Api.Domain.Identity.Services
{
    public interface IProductService
    {
        Task<long> Create(CreateProductDto request);
        Task<ProductEntity> GetById(long productId);
    }
}