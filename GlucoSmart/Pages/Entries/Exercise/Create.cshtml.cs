﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Authorization;

namespace GlucoSmart.Pages.Entries.Exercise
{
    [Authorize(Roles = "Patient")]
    public class CreateModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public CreateModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ExerciseEntry ExerciseEntry { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ExerciseEntry.Username = User.Identity.Name;
            ExerciseEntry.Date = DateTime.Now;
            
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.ExerciseEntry.Add(ExerciseEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}