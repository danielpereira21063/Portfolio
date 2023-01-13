using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Portfolio.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
