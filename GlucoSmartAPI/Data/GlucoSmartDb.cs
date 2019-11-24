using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GlucoSmartAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace GlucoSmart.Data
{
    public class GlucoSmartDb : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public GlucoSmartDb(DbContextOptions<GlucoSmartDb> options)
            : base(options)
        {
        }
    }
}
