using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Blog.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.Areas.Identity.Data.Seeder
{
    public class RoleSeeder
    {
        public  static async void Initialize(IServiceProvider serviceProvider )
        {
           ApplicationDbContext _db = serviceProvider.GetService<ApplicationDbContext>();
            // ApplicationDbContext _db = new ApplicationDbContext( serviceProvider.GetService<DbContextOptions<ApplicationDbContext>>());
            string[] roles = {"superadmin", "admin", "editor", "blogger"};


            if (!_db.Roles.Any())
            {
                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(_db);
                    await roleStore.CreateAsync(new IdentityRole(role));
                }
            }
            
            
            var user = new ApplicationUser
            {
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@blog.com",
                NormalizedEmail = "superadmin@BLOG.COM",
                EmailConfirmed = true,
                
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PhoneNumber = "+111111111111",
                PhoneNumberConfirmed = true
            };
            
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user,"secret");
            user.PasswordHash = hashed;

            if (!_db.Users.Any(u => u.Email == user.Email))
            {
                var userStore = new UserStore<ApplicationUser>(_db);
                await userStore.CreateAsync(user);
                AssignRolesToUser(serviceProvider, user.Email, roles, _db);
                
                await _db.SaveChangesAsync();
            }
           
        }

        private static async void AssignRolesToUser(IServiceProvider serviceProvider, string email, string[] roles, ApplicationDbContext db)
        {
            UserManager<ApplicationUser> userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            // ApplicationUser user = db.Users.FirstOrDefault(u => u.Email == email);
            
            await userManager.AddToRolesAsync(user, roles);
        }
        
    }
}