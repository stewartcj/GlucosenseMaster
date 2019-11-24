using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmartAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace GlucoSmart.Data
{
    public class DbApplicationUserRepository : IApplicationUserRepository
    {
        private GlucoSmartDb _db;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DbApplicationUserRepository(GlucoSmartDb db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
            return user;
        }

        public async Task<ApplicationUser> Read(string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            user.Roles = await _userManager.GetRolesAsync(user);
            return user;
        }
        
        public async Task AssignUserToRoleAsync(string userName, string roleName)
        {
            var roleCheck = await _roleManager.RoleExistsAsync(roleName);

            if (!roleCheck)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var user = await Read(userName);

            if (user != null)
            {
                if (!user.HasRole(roleName))
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

    }
}
