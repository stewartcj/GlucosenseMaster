using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmartMobile.Models
{
    public class FoodSearchCriteria
    {
        public string generalSearchInput { get; set; }
        public int pageNumber { get; set; }
        public bool requireAllWords { get; set; }
    }
}
