using Microsoft.AspNetCore.Identity;

namespace Portfolio.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
