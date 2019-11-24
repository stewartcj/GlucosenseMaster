using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlucoSmart.Models;
using GlucoSmart.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GlucoSmart.Pages.Patients
{
    [Authorize(Roles = "Doctor")]
    public class IndexModel : PageModel
    {
        private readonly GlucoSmartDb _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(GlucoSmartDb context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<ApplicationUser> Patients { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public String ErrorMessage { get; set; }
        
        public async Task OnGetAsync()
        {
            Patients = await _userManager.GetUsersInRoleAsync("Patient");
            CurrentUser = await _userManager.GetUserAsync(User);
        }

        
    }
}
