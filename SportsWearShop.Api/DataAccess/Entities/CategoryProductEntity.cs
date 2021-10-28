namespace SportsWearShop.Api.DataAccess.Entities
{
    public class CategoryProductEntity : BaseEntity
    {
        public long? ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public long? CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}