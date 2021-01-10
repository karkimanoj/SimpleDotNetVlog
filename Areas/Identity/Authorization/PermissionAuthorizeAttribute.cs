using System;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Areas.Identity.Authorization
{
    internal class PermissionAuthorizeAttribute : AuthorizeAttribute
    {
        const string POLICY_PREFIX = "Permission";

        public PermissionAuthorizeAttribute(string permissionName) => PermissionName = permissionName;

        public string PermissionName
        {
            get
            {
                var permissionName = Policy.Substring(POLICY_PREFIX.Length);
                if (String.IsNullOrWhiteSpace(permissionName))
                    return default(string);
                return permissionName;
            }

            set => Policy = $"{POLICY_PREFIX}{value}";
        }
    }
}