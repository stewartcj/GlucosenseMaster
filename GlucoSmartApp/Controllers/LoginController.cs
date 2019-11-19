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
using Newtonsoft.Json;

namespace GlucoSmart.Controllers
{
    class LoginController
    {
        public LoginModel Login { get; set; }
        public ApplicationUser User { get; set; }
        private HttpClient client = new HttpClient();
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/Login/";

        public LoginController(string username, string password)
        {
            Login = new LoginModel(username, password);
            GetUser();
        }
        private async void GetUser()
        {
            User = JsonConvert.DeserializeObject<ApplicationUser>(await client.GetStringAsync(apiUrl + $"{Login.Username},{Login.Password}"));

            if (User != null)
            {
                Toast.MakeText(Application.Context, "Login successful", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(Application.Context, "User not found. Please enter valid username and password.", ToastLength.Long).Show();
            }
        }
    }
}