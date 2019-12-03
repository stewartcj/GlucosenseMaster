using GlucoSmartMobile.Models;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterModel Model { get; set; }
        private HttpClient client = new HttpClient();
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/Register";
        public RegisterPage()
        {
            InitializeComponent();
            Model = new RegisterModel();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if (password.Text != confirmPassword.Text)
            {
                errorMessage.IsVisible = true;
                return;
            }
            Model.FirstName = firstName.Text;
            Model.LastName = lastName.Text;
            Model.DOB = dob.Date;
            Model.UserName = username.Text;
            Model.Password = password.Text;
            Model.ConfirmPassword = confirmPassword.Text;
            Model.Email = email.Text;
            Model.PhoneNumber = phoneNumber.Text;
            Model.DoctorID = doctorID.Text;
            Model.Weight = 0;

            var result = await client.PostAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                errorMessage.Text = "Something went wrong. Try again later";
            }
        }

        private void clearButton_Clicked(object sender, EventArgs e)
        {
            firstName.Text = "";
            lastName.Text = "";
            dob.Date = DateTime.Today;
            username.Text = "";
            email.Text = "";
            password.Text = "";
            confirmPassword.Text = "";
            phoneNumber.Text = "";
        }
    }
}