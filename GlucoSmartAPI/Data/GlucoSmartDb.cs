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

        public DbSet<GlucoseEntry> GlucoseEntry { get; set; }
        public DbSet<ExerciseEntry> ExerciseEntry { get; set; }
        public DbSet<FoodEntry> FoodEntry { get; set; }
    }
}
