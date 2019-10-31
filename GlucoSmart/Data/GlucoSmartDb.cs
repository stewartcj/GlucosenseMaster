using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Identity;

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
