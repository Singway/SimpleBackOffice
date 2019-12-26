using Microsoft.AspNetCore.Identity;
using SimpleBackOfficeAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBackOfficeAdmin.Services
{
    public static class CustomUserManager
    {
        public static async Task<IdentityResult> AddUsersToRoleAsync(this UserManager<IdentityUserV2> userManager,List<IdentityUserV2> users,string roleName)
        {
            IdentityResult result = null;
            for (int i = 0; i < users.Count; i++)
            {
                bool inRole = await userManager.IsInRoleAsync(users[i], roleName);
                if (inRole)
                {
                    continue;
                }
                result= await userManager.AddToRoleAsync(users[i], roleName);
                if (!result.Succeeded)
                {
                    return result;
                }
            }
            return result;
        }
        public static async Task<IdentityResult> RemoveUsersFromRoleAsync(this UserManager<IdentityUserV2> userManager, List<IdentityUserV2> users, string roleName)
        {
            IdentityResult result = null;
            for (int i = 0; i < users.Count; i++)
            {
                if (!await userManager.IsInRoleAsync(users[i], roleName))
                {
                    continue;
                }
                result = await userManager.RemoveFromRoleAsync(users[i], roleName);
                if (!result.Succeeded)
                {
                    return result;
                }
            }
            return result;
        }
    }
}
