using System.Threading.Tasks;
using SportsWearShop.Api.Domain.Identity.Models;

namespace SportsWearShop.Api.Domain.Identity.Services
{
    public interface IProductService
    {
        Task<long> Create(CreateProductDto request);
    }
}