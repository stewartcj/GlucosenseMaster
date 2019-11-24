using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GlucoSmart.Models;

namespace GlucoSmart.Controllers
{
    class ExerciseController
    {
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/Register/";
        ExerciseModel registrant;
        HttpClient client = new HttpClient();

        public ExerciseController(string activityId, string username, DateTime date, DateTime time, string description)
        {
            registrant = new ExerciseModel() {ActivityId = activityId, Username = username, Date = date, Time = time, Description = description};
            AddExercise();
        }

        private void AddExercise()
        {
            
        }
    }
}