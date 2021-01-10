using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Blog.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Post> Posts { get; set; }
        public List<PermissionUser> PermissionUsers { get; set; }
    }
}