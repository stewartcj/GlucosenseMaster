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

namespace GlucoSmart.Pages.Entries.Food
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FoodEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodEntryExists(FoodEntry.Id))
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

        private bool FoodEntryExists(int id)
        {
            return _context.FoodEntry.Any(e => e.Id == id);
        }
    }
}
