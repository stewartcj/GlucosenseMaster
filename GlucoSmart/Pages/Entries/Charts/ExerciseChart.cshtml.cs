using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GlucoSmart.Pages.Entries.Charts
{
    [Authorize(Roles = "Doctor,Patient")]
    public class ExerciseChartModel : PageModel
    {
        private readonly GlucoSmartDb _context;
        public List<int> UserEntries { get; set; }
        public IList<ExerciseEntry> Entries { get; set; }
        public List<string> Dates { get; set; }
        public string Username { get; set; }
        public ExerciseChartModel(GlucoSmartDb context)
        {
            _context = context;
        }

        public void OnGet(string username)
        {
            if (User.IsInRole("Doctor"))
            {
                Username = username;
            }

            if (User.IsInRole("Patient"))
            {
                Username = User.Identity.Name;
            }
            PopulateEntries();
        }

        private void PopulateEntries()
        {
            Entries = _context.ExerciseEntry.ToList<ExerciseEntry>();
            List<int> userEntries = new List<int>();
            List<string> dates = new List<string>();

            foreach(ExerciseEntry entry in Entries)
            {
                if (entry.Username == Username)
                {
                    dates.Add(entry.Date.ToShortDateString());
                    userEntries.Add(entry.Minutes);    
                }
            }

            UserEntries = userEntries;
            Dates = dates;
        }
    }
}