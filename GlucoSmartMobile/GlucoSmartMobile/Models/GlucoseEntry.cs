using System;

namespace GlucoSmartMobile.Models
{
    public class GlucoseEntry
    {
        public enum ReadingType
        {
            PreMeal, PostMeal
        }

        public enum MealType
        {
            Breakfast, Lunch, Dinner
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public int BloodSugar { get; set; }
        public DateTime Date { get; set; }
        public ReadingType Reading { get; set; }
        public MealType Meal { get; set; }
    }
}
