using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmartMobile.Models
{
    public class SearchQuery
    {
        public FoodSearchCriteria FoodSearchCriteria { get; set; }
        public int TotalHits { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<FoodAPI> Foods { get; set; }
    }
}
