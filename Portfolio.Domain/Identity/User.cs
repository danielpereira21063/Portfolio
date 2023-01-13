using Microsoft.AspNetCore.Identity;

namespace Portfolio.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
