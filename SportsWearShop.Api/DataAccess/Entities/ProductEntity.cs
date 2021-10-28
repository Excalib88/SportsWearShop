using System.Collections.Generic;

namespace SportsWearShop.Api.DataAccess.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public List<PictureEntity> Photos { get; set; }
    }
}