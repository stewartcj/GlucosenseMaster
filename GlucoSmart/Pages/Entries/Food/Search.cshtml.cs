using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlucoSmart.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace GlucoSmart.Pages.Entries.Food
{
    [Authorize(Roles = "Patient")]
    public class SearchModel : PageModel
    {
        public List<FoodAPI> Foods { get; set; }
        private HttpClient _client = new HttpClient();
        private string apiURL = "https://api.nal.usda.gov/fdc/v1/search?api_key=Waqn5RfjG3FvPYtChsljWbV6ISD2ajSyoWRLHDqb";

        public void OnGet()
        {
            
        }

        [BindProperty]
        public FoodSearchCriteria SearchCriteria { get; set; }
        public SearchQuery Query { get; set; }

        public async Task<IActionResult> OnPost()
        {
            StringContent food = new StringContent(JsonConvert.SerializeObject(SearchCriteria).ToString(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(apiURL, food);
            Query = JsonConvert.DeserializeObject<SearchQuery>(await response.Content.ReadAsStringAsync());

            return Page();
        }
    }
}