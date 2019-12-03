using System;

namespace GlucoSmartMobile.Models
{
    public class FoodEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Carbs { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }

    }
}
