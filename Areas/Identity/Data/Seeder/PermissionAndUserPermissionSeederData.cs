using System.Collections.Generic;
using Blog.Models;
using System;
using System.Linq;

namespace Blog.Areas.Identity.Data.Seeder
{
    public static class PermissionAndUserPermissionSeederData
    {
        public static readonly string[] Permissions = {
            "add_post",
            "edit_post",
            "delete_post",
                
            "add_category",
            "edit_category",
            "delete_category",
                
            "add_tag",
            "edit_tag",
            "delete_tag",
                
            "add_comment",
            "edit_comment",
            "delete_comment",
                
            "add_user",
            "edit_user",
            "activate_deactivate_user",
                
            "verify_post"
        };
        public static (Permission[], PermissionUser[]) Data()
        {
            var permissionList = new List<Permission>();
            for (int i = 0; i < Permissions.Length; i++)
            {
                permissionList.Add(
                    new Permission()
                    {
                        PermissionId = i + 1,
                        Name = Permissions[i],
                        DisplayName = Permissions[i].Replace('_', ' ')
                    }
                );
            }
            
            //add permission user seeder for 2 users. 
            //5c49772c-a43f-45d5-be7b-55a877a3644e
            //d373e67d-eb8d-44da-bf8b-f13c2410de76
            List<PermissionUser> permissionUsers = new List<PermissionUser>();
            int[] bloggerPermissions = {1,2,3,7,8,9,10,11,12 };
            int count = 0;
            for (int i = 1; i <= Permissions.Length; i++)
            {
                permissionUsers.Add(
                    new PermissionUser()
                    {
                        PermissionUserId = ++count,
                        PermissionId = i,
                        UserId = "5c49772c-a43f-45d5-be7b-55a877a3644e"
                    });
                
                if(bloggerPermissions.Contains(i))
                    permissionUsers.Add(
                        new PermissionUser()
                        {
                            PermissionUserId = ++count,
                            PermissionId = i,
                            UserId = "d373e67d-eb8d-44da-bf8b-f13c2410de76"
                        });
            }
            return (permissionList.ToArray(), permissionUsers.ToArray());
        }
    }
}