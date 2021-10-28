namespace SportsWearShop.Api.DataAccess.Entities
{
    public class PictureEntity : BaseEntity
    {
        public string Filename { get; set; }
        public byte[] Data { get; set; }
        public long? ProductId { get; set; }
        public ProductEntity Product { get; set; }
    }
}