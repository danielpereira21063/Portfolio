using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Portfolio.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
