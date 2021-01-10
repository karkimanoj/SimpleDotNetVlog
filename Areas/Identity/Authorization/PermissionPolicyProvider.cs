using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;

namespace Blog.Areas.Identity.Authorization
{
    internal class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        private const string POLICY_PREFIX = "Permission";
        private readonly DefaultAuthorizationPolicyProvider _backupPolicyProvider;

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options) =>
            _backupPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        
        //if policy is specified, 
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        { 
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
            {
                string permissionName = policyName.Substring(POLICY_PREFIX.Length);
                if (!String.IsNullOrWhiteSpace(permissionName))
                {
                    //CookieAuthenticationDefaults.AuthenticationScheme created problem
                    // var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
                    var policy = new AuthorizationPolicyBuilder();
                    policy.AddRequirements(new PermissionRequirement(permissionName));
                    return Task.FromResult(policy.Build());
                }
            }
            return _backupPolicyProvider.GetPolicyAsync(policyName);
        }
        
        //for  [Authorize] only 
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            // return Task.FromResult(new  AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
            //todo: parameter CookieAuthenticationDefaults.AuthenticationScheme in above code generates error
            return Task.FromResult(new  AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
            
        }
            
        
        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => 
            Task.FromResult<AuthorizationPolicy>(null);
    }
}