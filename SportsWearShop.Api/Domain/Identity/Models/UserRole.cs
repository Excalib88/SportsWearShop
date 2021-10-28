namespace SportsWearShop.Api.Domain.Identity.Models
{
    public static class UserRole
    {
        public const string Administrator = "Administrator";
        public const string Moderator = "Moderator";
        public const string Buyer = "Buyer";

        public const string All = "Administrator,Moderator,Buyer";
    }
}