using Microsoft.AspNetCore.Identity;

namespace SportsWearShop.Api.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}