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

namespace GlucoSmart.Pages.Entries.Exercise
{
    [Authorize(Roles = "Doctor,Patient")]
    public class DetailsModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public DetailsModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        public ExerciseEntry ExerciseEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExerciseEntry = await _context.ExerciseEntry.FirstOrDefaultAsync(m => m.Id == id);

            if (ExerciseEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
