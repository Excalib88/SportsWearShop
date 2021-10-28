using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsWearShop.Api.DataAccess.Entities;

namespace SportsWearShop.Api.DataAccess
{
    public class ApiDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<PictureEntity> Pictures { get; set; }
        public DbSet<CategoryProductEntity> CategoryProducts { get; set; }
    }
}