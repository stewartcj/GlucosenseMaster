using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmart.Models
{
    public class FoodAPI
    {
        public int FdcId { get; set; }
        public string Description { get; set; }
        public string AdditionalDescriptions { get; set; }
        public string DataType { get; set; }
        public string FoodCode { get; set; }
        public string PublishedDate { get; set; }
        public string AllHighlightFields { get; set; }
        public double Score { get; set; }
        public string NdbNumber { get; set; }
    }
}
