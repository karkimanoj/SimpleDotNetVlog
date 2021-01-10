using System;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Controllers
{
    [Authorize(Roles = "superadmin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }

        // public async Task<IActionResult> Index()
        // {
        //     
        // }
        
        
        public async Task<IActionResult> Create()
        {
            UserRoleViewModel useRole = new UserRoleViewModel()
            {
                Roles = await GetRoleList()
            };
            return View(useRole);
        }
        
        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRoleViewModel userRole)
        {
            // if (!ModelState.IsValid)
            //     return View(userRole);
            ApplicationUser newUser = new ApplicationUser()
            {
                // Id = Guid.NewGuid().ToString(),
                UserName = userRole.UserName,
                Email = userRole.Email,
                EmailConfirmed = true
            };
            
            if (!await RoleExists(userRole.Role))
            {
                TempData["failMessage"] = $"role `{userRole.Role}` not found";
                userRole.Roles = await GetRoleList();
                return View(userRole);
            }
            
            var result = await _userManager.CreateAsync(newUser, userRole.Password);
            
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(" ", error.Description);
                userRole.Roles = await GetRoleList();
                return View(userRole);
            }
            
            var roleResult  = await _userManager.AddToRoleAsync(newUser, userRole.Role);
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                    ModelState.AddModelError(" ", error.Description);
                userRole.Roles = await GetRoleList();
                return View(userRole);
            }
            
            TempData["successMessage"] = $"successfully added new user {userRole.UserName}";
            return RedirectToAction(nameof(Create));
        }

        private async Task<bool> RoleExists(string roleName)
        {
            return await _db.Roles.AnyAsync(r => r.Name == roleName);
        }

        private async Task<SelectList> GetRoleList()
        {
            return new SelectList((await _db.Roles.ToListAsync()));
        }
       
    }
}