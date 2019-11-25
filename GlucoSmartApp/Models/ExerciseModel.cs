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
	class ExerciseModel
    {
		public string ActivityId { get; set; }
        public string Username { get; set; }
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public string Description { get; set; }
		
		
		public ExerciseModel()
        {

        }
        
    }
}