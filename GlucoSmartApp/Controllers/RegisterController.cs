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
    class RegisterController
    {
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/Register/";
        RegisterModel registrant;
        HttpClient client = new HttpClient();

        public RegisterController(string userName, string email, string password, string confirmPassword, string firstName, string lastName, DateTime dob, string doctorID, int weight)
        {
            registrant = new RegisterModel() {UserName = userName, Email = email, Password = password, ConfirmPassword = confirmPassword, FirstName = firstName, LastName = lastName, DOB = dob, DoctorID = doctorID, Weight = weight };
            RegisterUser();
        }

        private void RegisterUser()
        {
            
        }
    }
}