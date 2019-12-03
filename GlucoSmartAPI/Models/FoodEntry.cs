using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlucoSmartAPI.Models
{
    public class FoodEntry
    {
        [Required,Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Food")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Carbs")]
        public int Carbs { get; set; }
        [Required]
        [Display(Name = "Calories")]
        public int Calories { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Username { get; set; }

    }
}
