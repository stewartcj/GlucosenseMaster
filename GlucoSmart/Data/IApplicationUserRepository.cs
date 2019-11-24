using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmart.Models;

namespace GlucoSmart.Data
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> Read(string userName);
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
        Task AssignUserToRoleAsync(string userName, string roleName);
    }
}
