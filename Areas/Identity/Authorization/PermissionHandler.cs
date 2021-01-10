using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Areas.Identity.Authorization
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        //public PermissionHandler(ApplicationDbContext dbContext) => _db = dbContext;

        public PermissionHandler(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _db = dbContext;
            _userManager = userManager;

        }
        
        protected override  Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            string userId = _userManager.GetUserId(context.User);

            var innerPermissionQuery = from permission in _db.Permission 
                where permission.Name == requirement.PermissionName
                select permission.PermissionId;
            
            var permissionExists = (from permissionUser in _db.PermissionUser
                where permissionUser.UserId == userId
                where innerPermissionQuery.Contains(permissionUser.PermissionId)
                select 1).Any();
                
            if(permissionExists)
                context.Succeed(requirement);
            
            return Task.CompletedTask;
        }
    }
}