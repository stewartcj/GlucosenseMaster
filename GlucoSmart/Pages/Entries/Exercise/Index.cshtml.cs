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
    public class IndexModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public IndexModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        public IList<ExerciseEntry> ExerciseEntry { get;set; }
        public List<ExerciseEntry> UserEntries { get; set; }
        public string Username { get; set; }

        public async Task OnGetAsync(string username)
        {
            Username = username;
            UserEntries = await _context.ExerciseEntry.ToListAsync();
            GetUserEntries();
        }

        private void GetUserEntries()
        {
            List<ExerciseEntry> entries = new List<ExerciseEntry>();
            foreach (ExerciseEntry entry in UserEntries)
            {
                if (User.IsInRole("Patient"))
                {
                    if (entry.Username == User.Identity.Name)
                    {
                        entries.Add(entry);
                    }
                }

                if (User.IsInRole("Doctor"))
                {
                    if (entry.Username == Username)
                    {
                        entries.Add(entry);
                    }
                }
            }

            ExerciseEntry = entries;
        }
    }
}
