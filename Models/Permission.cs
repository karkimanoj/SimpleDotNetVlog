using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Permission
    {
        public long PermissionId { get; set; }
        [Required][StringLength(256)]
        public string Name { get; set; }
        [Required][StringLength(256)]
        public string DisplayName { get; set; }
        
        public List<PermissionUser> PermissionUsers { get; set; } 
        
    }
}