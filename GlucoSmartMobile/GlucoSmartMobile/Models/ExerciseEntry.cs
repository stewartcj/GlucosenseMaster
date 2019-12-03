using System;

namespace GlucoSmartMobile.Models
{
    public class ExerciseEntry
    {
        public enum ExerciseType
        {
            Cardio, Weightlifting
        }

        public enum IntensityType
        {
            Low, Medium, High
        }
        public string Username { get; set; }
        public int Minutes { get; set; }
        public ExerciseType Exercise { get; set; }
        public IntensityType Intensity { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        
    }
}
