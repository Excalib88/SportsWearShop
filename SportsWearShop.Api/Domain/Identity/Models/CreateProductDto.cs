using Microsoft.AspNetCore.Http;

namespace SportsWearShop.Api.Domain.Identity.Models
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public IFormFileCollection Files { get; set; }
        public long? CategoryId { get; set; }
    }
}