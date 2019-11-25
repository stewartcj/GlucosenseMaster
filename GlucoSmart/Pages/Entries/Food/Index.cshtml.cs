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
    public class IndexModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;

        public IndexModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        public List<FoodEntry> FoodEntry { get; set; }
        public IList<FoodEntry> Entries { get; set; }
        public string Username { get; set; }

        public void OnGet(string username)
        {
            Username = username;
            PopulateEntries();
        }

        private void PopulateEntries()
        {
            List<FoodEntry> entries = new List<FoodEntry>();
            Entries = _context.FoodEntry.ToList();
            foreach (FoodEntry entry in Entries)
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

            FoodEntry = entries;
        }
    }
}
