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
    [Authorize(Roles = "Doctor,Patient")]
    public class IndexModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public IndexModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        public List<GlucoseEntry> GlucoseEntry { get;set; }
        public IList<GlucoseEntry> Entries { get; set; }
        public string Username { get; set; }

        public void OnGet(string username)
        {
            Username = username;
            PopulateEntries();
        }

        private void PopulateEntries()
        {
            List<GlucoseEntry> entries = new List<GlucoseEntry>();
            Entries = _context.GlucoseEntry.ToList();
            foreach(GlucoseEntry entry in Entries)
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

            GlucoseEntry = entries;
        }

    }
}
