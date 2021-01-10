using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Models
{
    public class UserRoleViewModel
    {
        [Required][StringLength(256, MinimumLength = 1)]
        public string UserName { get; set; }
        
        [Required][StringLength(256, MinimumLength = 1)][DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required][StringLength(256, MinimumLength = 6)][DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required][StringLength(256, MinimumLength = 1)]
        [DisplayName("Password Confirmation")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
        
        public SelectList Roles { get; set; }
        
        [Required][StringLength(256, MinimumLength = 1)]
        public string Role { get; set; }
    }
}