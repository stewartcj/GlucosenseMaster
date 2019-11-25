using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Authorization;

namespace GlucoSmart.Pages.Entries.Exercise
{
    [Authorize(Roles = "Patient")]
    public class EditModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public EditModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ExerciseEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseEntryExists(ExerciseEntry.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ExerciseEntryExists(int id)
        {
            return _context.ExerciseEntry.Any(e => e.Id == id);
        }
    }
}
