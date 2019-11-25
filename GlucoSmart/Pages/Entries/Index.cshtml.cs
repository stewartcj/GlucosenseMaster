using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GlucoSmart.Pages.Entries
{
    [Authorize(Roles = "Doctor,Patient")]
    public class IndexModel : PageModel
    {
        private readonly GlucoSmartDb _context;
        public IList<GlucoseEntry> GlucoseEntries { get; set; }
        public IList<ExerciseEntry> ExerciseEntries { get; set; }
        public IList<FoodEntry> FoodEntries { get; set; }
        public List<GlucoseEntry> UserGluEntries { get; set; }
        public List<ExerciseEntry> UserExEntries { get; set; }
        public List<FoodEntry> UserFoodEntries { get; set; }
        public string Username { get; set; }

        public IndexModel(GlucoSmartDb context)
        {
            _context = context;
        }

        public void OnGet(string username)
        {
            GlucoseEntries = _context.GlucoseEntry.ToList();
            ExerciseEntries = _context.ExerciseEntry.ToList();
            FoodEntries = _context.FoodEntry.ToList();

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
            List<GlucoseEntry> gluEntries = new List<GlucoseEntry>();
            List<ExerciseEntry> exEntries = new List<ExerciseEntry>();
            List<FoodEntry> foodEntries = new List<FoodEntry>();
            int range;

            foreach (GlucoseEntry entry in GlucoseEntries)
            {
                if (entry.Username == Username)
                {
                    gluEntries.Add(entry);
                }
            }

            foreach (ExerciseEntry entry in ExerciseEntries)
            {
                if (entry.Username == Username)
                {
                    exEntries.Add(entry);
                }
            }

            foreach (FoodEntry entry in FoodEntries)
            {
                if (entry.Username == Username)
                {
                    foodEntries.Add(entry);
                }
            }

            if (gluEntries.Count < 10)
            {
                UserGluEntries = gluEntries;
            }
            else
            {
                range = gluEntries.Count - 10;
                gluEntries.RemoveRange(0, range);
                UserGluEntries = gluEntries;
            }

            if (exEntries.Count < 10)
            {
                UserExEntries = exEntries;
            }
            else
            {
                range = exEntries.Count - 10;
                exEntries.RemoveRange(0, range);
                UserExEntries = exEntries;
            }

            if (foodEntries.Count < 10)
            {
                UserFoodEntries = foodEntries;
            }
            else
            {
                range = foodEntries.Count - 10;
                foodEntries.RemoveRange(0, range);
                UserFoodEntries = foodEntries;
            }

        }
    }
}