﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmart.Models
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

        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int BloodSugar { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public ReadingType Reading { get; set; }

        [Required]
        public MealType Meal { get; set; }
    }
}
