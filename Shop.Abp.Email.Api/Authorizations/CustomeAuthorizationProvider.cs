using Abp;
using Abp.Authorization;
using Abp.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Authorizations
{
    /// <summary>
    /// test
    /// </summary>
    public class CustomePermissionChecker: IPermissionChecker
    {
        public Task<bool> IsGrantedAsync(string permissionName)
        {
            return Task.FromResult(true);
        }

        public Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            return Task.FromResult(true);
        }
        public bool IsGranted(string permissionName)
        {
            return "admin".Equals(permissionName);
        }

        public bool IsGranted(UserIdentifier user, string permissionName)
        {
            return true;
        }
    }
    public class CustomeAuthorizationProvider : AuthorizationProvider
    {

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission("admin");
        }
    }
}
