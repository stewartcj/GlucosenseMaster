using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Authorization;

namespace GlucoSmart.Pages.Entries.Food
{
    [Authorize(Roles = "Doctor,Patient")]
    public class DetailsModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public DetailsModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        public FoodEntry FoodEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodEntry = await _context.FoodEntry.FirstOrDefaultAsync(m => m.Id == id);

            if (FoodEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
