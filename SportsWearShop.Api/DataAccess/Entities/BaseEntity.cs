using System;

namespace SportsWearShop.Api.DataAccess.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}