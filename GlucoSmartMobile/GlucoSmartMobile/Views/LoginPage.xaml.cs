using GlucoSmartMobile.Models;
using GlucoSmartMobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlucoSmartMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginModel LoginModel { get; set; }
        private HttpClient client = new HttpClient();
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/";
        public ApplicationUser User { get; set; }
        private List<GlucoseEntry> glucEntries;
        private List<ExerciseEntry> exEntries;
        private List<FoodEntry> foodEntries;

        public LoginPage()
        {
            LoginModel = new LoginModel();
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
        }

        private async void loginButton_Clicked(object sender, EventArgs e)
        {
            if (username.Text == null || password.Text == null)
            {
                errorMessage.IsVisible = true;
                return;
            }
            LoginModel.Username = username.Text;
            LoginModel.Password = password.Text;

            User = JsonConvert.DeserializeObject<ApplicationUser>(await client.GetStringAsync(apiUrl + $"Login/{LoginModel.Username},{LoginModel.Password}"));

            if (User != null)
            {
                User.LoggedIn = true;
                App.User = User;

                DependencyService.Register<GlucoseDataStore>();
                DependencyService.Register<ExerciseDataStore>();
                DependencyService.Register<FoodDataStore>();

                glucEntries = JsonConvert.DeserializeObject<List<GlucoseEntry>>(await client.GetStringAsync(apiUrl + $"Glucose/{LoginModel.Username}"));
                exEntries = JsonConvert.DeserializeObject<List<ExerciseEntry>>(await client.GetStringAsync(apiUrl + $"Exercise/{LoginModel.Username}"));
                foodEntries = JsonConvert.DeserializeObject<List<FoodEntry>>(await client.GetStringAsync(apiUrl + $"Food/{LoginModel.Username}"));

                Application.Current.MainPage = new MainPage(glucEntries, exEntries, foodEntries);
                await Navigation.PopAsync();
                
            }
            else
            {
                errorMessage.IsVisible = true;
            }
        }

        private void forgotButton_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }


    }
}