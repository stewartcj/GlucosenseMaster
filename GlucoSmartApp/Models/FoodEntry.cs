using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GlucoSmart.Models
{
    class FoodEntry
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public int Carbs { get; set; }

        public int Calories { get; set; }

        public DateTime Date { get; set; }

    }
}