using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Blog.Areas.Identity.Data.Seeder
{
    public static class RoleAndUserRoleSeederData
    {
        public static (IdentityRole[], IdentityUserRole<string>[]) Data()
        {
            IdentityRole[] roles =
            {
                new IdentityRole
                {
                    Id = "895078dc-1225-4c5b-be43-2ff61cdca597",
                    ConcurrencyStamp = "aba0693b-959c-4246-9ef5-7e80e6cc3656",
                    Name = "superadmin",
                    NormalizedName = "SUPERADMIN"
                },

                new IdentityRole
                {
                    Id = "a3a0a50c-3c43-4609-8be0-782aaf42f075",
                    ConcurrencyStamp = "23b6af00-8980-49e7-9d52-3c0bb48d287b",
                    Name = "admin", NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "757c5db6-2d1b-4957-b301-3fddafb89fee",
                    ConcurrencyStamp = "c8836d6a-3d1e-446c-b4d9-327b307a03ae",
                    Name = "editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = "deda37d1-6eb5-49e0-99d6-04bdc7f89637",
                    ConcurrencyStamp = "9864535c-085a-447c-a592-8ad14fe40b97",
                    Name = "blogger",
                    NormalizedName = "BLOGGER"
                }
            };

        string[] usersToBeAssignedAllRoles = { "1e299ddc-4366-499f-887a-246f4a51c0e2","5c49772c-a43f-45d5-be7b-55a877a3644e"};
      
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            foreach (var user in usersToBeAssignedAllRoles)
            {
                userRoles.Add(
                    new IdentityUserRole<string>()
                    {
                        UserId = user,
                        RoleId = "895078dc-1225-4c5b-be43-2ff61cdca597"
                    }
                );
                userRoles.Add(
                    new IdentityUserRole<string>()
                    {
                        UserId = user,
                        RoleId = "a3a0a50c-3c43-4609-8be0-782aaf42f075"
                    }
                );
                userRoles.Add(
                    new IdentityUserRole<string>()
                    {
                        UserId = user,
                        RoleId = "757c5db6-2d1b-4957-b301-3fddafb89fee"
                    }
                );
                userRoles.Add(
                    new IdentityUserRole<string>()
                    {
                        UserId = user,
                        RoleId = "deda37d1-6eb5-49e0-99d6-04bdc7f89637"
                    }
                );
            }
            
            userRoles.Add(new IdentityUserRole<string>()
            {
                UserId = "d373e67d-eb8d-44da-bf8b-f13c2410de76",
                RoleId = "deda37d1-6eb5-49e0-99d6-04bdc7f89637"
            });
            
            return (roles ,userRoles.ToArray());
        }
    }
}