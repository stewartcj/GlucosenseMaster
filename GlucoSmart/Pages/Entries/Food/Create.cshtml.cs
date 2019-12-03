using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlucoSmart.Data;
using GlucoSmart.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace GlucoSmart.Pages.Entries.Food
{
    [Authorize(Roles = "Patient")]
    public class CreateModel : PageModel
    {
        private readonly GlucoSmart.Data.GlucoSmartDb _context;
        private HttpClient _client = new HttpClient();
        private int FdcId { get; set; }
        private string apiKey = "Waqn5RfjG3FvPYtChsljWbV6ISD2ajSyoWRLHDqb";
        public FoodObject FoodObject { get; set; }
        public string Name { get; set; }
        public int Carbs { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; }

        public CreateModel(GlucoSmart.Data.GlucoSmartDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int fdcId)
        {
            int carbs, calories;

            FdcId = fdcId;
            string apiURL = $"https://api.nal.usda.gov/fdc/v1/{FdcId}?api_key={apiKey}";
            FoodObject = JsonConvert.DeserializeObject<FoodObject>(await _client.GetStringAsync(apiURL));

            Name = FoodObject.Description;

            foreach(FoodNutrient nutrient in FoodObject.FoodNutrients)
            {
                if (nutrient.Nutrient.Name.ToLower().Contains("carbohydrate") || nutrient.Nutrient.Name.ToLower().Contains("carbs"))
                {
                    Int32.TryParse(nutrient.Nutrient.Number, out carbs);
                    Carbs = carbs;
                }

                if (nutrient.Nutrient.Name.ToLower().Contains("energy"))
                {
                    Int32.TryParse(nutrient.Nutrient.Number, out calories);
                    Calories = calories;
                }
            }

            return Page();
        }

        [BindProperty]
        public FoodEntry FoodEntry { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            FoodEntry.Username = User.Identity.Name;
            FoodEntry.Date = DateTime.Now;
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.FoodEntry.Add(FoodEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
