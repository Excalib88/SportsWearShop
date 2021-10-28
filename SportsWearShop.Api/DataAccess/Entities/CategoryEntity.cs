namespace SportsWearShop.Api.DataAccess.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public long? ParentCategoryId { get; set; }
        public long? ChildCategoryId { get; set; }
    }
}