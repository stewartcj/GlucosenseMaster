using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmart.Models
{
    public class Nutrient
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public string UnitName { get; set; }
    }

    public class FoodNutrient
    {
        public int Id { get; set; }
        public Nutrient Nutrient { get; set; }
    }

    public class FoodObject
    {
        public string Description { get; set; }
        public List<FoodNutrient> FoodNutrients { get; set; }
    }
}
