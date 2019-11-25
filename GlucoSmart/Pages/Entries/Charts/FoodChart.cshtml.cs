using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GlucoSmart.Pages.Entries.Charts
{
    public class FoodChartModel : PageModel
    {
        private readonly GlucoSmartDb _context;
        public FoodChartModel(GlucoSmartDb context)
        {
            _context = context;
        }

        public IList<FoodEntry> Entries { get; set; }
        public List<string> Dates { get; set; }
        public List<int> Carbs { get; set; }
        public List<int> Calories { get; set; }
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
            Entries = _context.FoodEntry.ToList();
            PopulateNutrientEntries();

        }

        private void PopulateNutrientEntries()
        {
            List<string> dates = new List<string>();
            List<int> carbs = new List<int>();
            List<int> calories = new List<int>();
            int carbSum = 0;
            int calorieSum = 0;

            for (int i = 0; i < Entries.Count; i++)
            {
                if (i != Entries.Count - 1)
                {
                    if (Entries[i].Date.ToShortDateString().Equals(Entries[i + 1].Date.ToShortDateString()))
                    {
                        carbSum += Entries[i].Carbs;
                        calorieSum += Entries[i].Calories;
                    }
                    else
                    {
                        carbSum += Entries[i].Carbs;
                        calorieSum += Entries[i].Calories;

                        dates.Add(Entries[i].Date.ToShortDateString());
                        carbs.Add(carbSum);
                        calories.Add(calorieSum);

                        carbSum = 0;
                        calorieSum = 0;
                    }
                }
                else
                {
                    carbSum += Entries[i].Carbs;
                    calorieSum += Entries[i].Calories;

                    dates.Add(Entries[i].Date.ToShortDateString());
                    carbs.Add(carbSum);
                    calories.Add(calorieSum);

                    carbSum = 0;
                    calorieSum = 0;
                }
            }

            Dates = dates;
            Carbs = carbs;
            Calories = calories;

        }
    }
}