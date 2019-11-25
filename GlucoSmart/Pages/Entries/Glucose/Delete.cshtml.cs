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

namespace GlucoSmart.Pages.Entries.Glucose
{
    [Authorize(Roles = "Patient")]
    public class DeleteModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public DeleteModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        [BindProperty]
        public GlucoseEntry GlucoseEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GlucoseEntry = await _context.GlucoseEntry.FirstOrDefaultAsync(m => m.Id == id);

            if (GlucoseEntry == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GlucoseEntry = await _context.GlucoseEntry.FindAsync(id);

            if (GlucoseEntry != null)
            {
                _context.GlucoseEntry.Remove(GlucoseEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
