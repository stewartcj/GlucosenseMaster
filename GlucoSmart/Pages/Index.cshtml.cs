using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GlucoSmart.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(ILogger<IndexModel> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (_signInManager.IsSignedIn(User))
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles[0] == "Doctor")
                {
                    return LocalRedirect("~/Patients/Index");
                }
                else if(roles[0] == "Patient")
                {
                    return LocalRedirect("~/Entries/Index");
                }
                else
                {
                    return Page();
                }
            }

            return Page();
        }
    }
}
