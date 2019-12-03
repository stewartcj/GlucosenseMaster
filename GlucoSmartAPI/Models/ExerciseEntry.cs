using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmartAPI.Models
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
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int Minutes { get; set; }
        [Required]
        public ExerciseType Exercise { get; set; }

        [Required]

        public IntensityType Intensity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
    }
}
