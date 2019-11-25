using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Authorization;

namespace GlucoSmart.Pages
{
    [Authorize(Roles = "Doctor,Patient")]
    public class GlucoseChartModel : PageModel
    {
        private readonly GlucoSmartDb _context;
        public GlucoseChartModel(GlucoSmartDb context)
        {
            _context = context;
        }

        public IList<GlucoseEntry> Entries { get; set; }
        public List<string> BreakfastDates { get; set; }
        public List<string> LunchDates { get; set; }
        public List<string> DinnerDates { get; set; }
        public List<int> BreakfastPreReadings { get; set; }
        public List<int> BreakfastPostReadings { get; set; }
        public List<int> LunchPreReadings { get; set; }
        public List<int> LunchPostReadings { get; set; }
        public List<int> DinnerPreReadings { get; set; }
        public List<int> DinnerPostReadings { get; set; }
        public string Username { get; set; }

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
            Entries = _context.GlucoseEntry.ToList<GlucoseEntry>();
            PopulateBreakfastEntries();
            PopulateLunchEntries();
            PopulateDinnerEntries();

        }

        private void PopulateBreakfastEntries()
        {
            List<string> dates = new List<string>();
            List<int> breakfastPre = new List<int>();
            List<int> breakfastPost = new List<int>();

            foreach (GlucoseEntry entry in Entries)
            {
                if (entry.Username == Username && entry.Meal == GlucoseEntry.MealType.Breakfast)
                {
                    if (entry.Reading == GlucoseEntry.ReadingType.PreMeal)
                    {
                        dates.Add(entry.Date.ToShortDateString());
                        breakfastPre.Add(entry.BloodSugar);
                    }

                    if (entry.Reading == GlucoseEntry.ReadingType.PostMeal)
                    {
                        breakfastPost.Add(entry.BloodSugar);
                    }
                }
            }

            BreakfastDates = dates;
            BreakfastPreReadings = breakfastPre;
            BreakfastPostReadings = breakfastPost;

        }

        private void PopulateLunchEntries()
        {
            List<string> dates = new List<string>();
            List<int> lunchPre = new List<int>();
            List<int> lunchPost = new List<int>();

            foreach (GlucoseEntry entry in Entries)
            {
                if (entry.Username == Username && entry.Meal == GlucoseEntry.MealType.Lunch)
                {
                    if (entry.Reading == GlucoseEntry.ReadingType.PreMeal)
                    {
                        dates.Add(entry.Date.ToShortDateString());
                        lunchPre.Add(entry.BloodSugar);
                    }

                    if (entry.Reading == GlucoseEntry.ReadingType.PostMeal)
                    {
                        lunchPost.Add(entry.BloodSugar);
                    }
                }
            }

            LunchDates = dates;
            LunchPreReadings = lunchPre;
            LunchPostReadings = lunchPost;
        }

        private void PopulateDinnerEntries()
        {
            List<string> dates = new List<string>();
            List<int> dinnerPre = new List<int>();
            List<int> dinnerPost = new List<int>();

            foreach (GlucoseEntry entry in Entries)
            {
                if (entry.Username == Username && entry.Meal == GlucoseEntry.MealType.Dinner)
                {
                    if (entry.Reading == GlucoseEntry.ReadingType.PreMeal)
                    {
                        dates.Add(entry.Date.ToShortDateString());
                        dinnerPre.Add(entry.BloodSugar);
                    }

                    if (entry.Reading == GlucoseEntry.ReadingType.PostMeal)
                    {
                        dinnerPost.Add(entry.BloodSugar);
                    }
                }
            }

            DinnerDates = dates;
            DinnerPreReadings = dinnerPre;
            DinnerPostReadings = dinnerPost;
        }
    }
}