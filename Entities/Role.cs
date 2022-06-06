using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ASP_Project.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
