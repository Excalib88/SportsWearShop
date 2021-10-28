using System.Collections.Generic;
using SportsWearShop.Api.DataAccess.Entities;

namespace SportsWearShop.Api.Domain.Identity.Services
{
    public interface IJwtGenerator
    {
        string CreateToken(ApplicationUser user, List<string> roles);
    }
}