using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GlucoSmartMobile.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace GlucoSmartMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class FoodEntryPage : ContentPage
    {
        private string apiKey = "Waqn5RfjG3FvPYtChsljWbV6ISD2ajSyoWRLHDqb";
        private HttpClient _client = new HttpClient();
        public FoodObject FoodObject { get; set; }
        public FoodEntry Food { get; set; }
        private string Name { get; set; }
        private int Carbs { get; set; }
        private int Calories { get; set; }
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/Food";


        public FoodEntryPage(int fdcId)
        {
            InitializeComponent();

            GetFood(fdcId);
        }

        private async void GetFood(int fdcId)
        {
            int carbs, calories;

            string apiURL = $"https://api.nal.usda.gov/fdc/v1/{fdcId}?api_key={apiKey}";
            FoodObject = JsonConvert.DeserializeObject<FoodObject>(await _client.GetStringAsync(apiURL));

            Name = FoodObject.Description;

            foreach (FoodNutrient nutrient in FoodObject.FoodNutrients)
            {
                if (nutrient.Nutrient.Name.ToLower().Contains("carbohydrate") || nutrient.Nutrient.Name.ToLower().Contains("carbs"))
                {
                    Int32.TryParse(nutrient.Nutrient.Number, out carbs);
                    Carbs = carbs;
                }

                if (nutrient.Nutrient.Name.ToLower().Contains("energy"))
                {
                    Int32.TryParse(nutrient.Nutrient.Number, out calories);
                    Calories = calories;
                }
            }

            Food = new FoodEntry()
            {
                Name = Name,
                Calories = Calories,
                Carbs = Carbs,
                Username = App.User.UserName,
                Date = DateTime.Now
            };

            FoodNameEntry.Text = Food.Name;
            FoodCarbEntry.Text = $"{Food.Carbs}";
            FoodCalEntry.Text = $"{Food.Calories}";
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            await _client.PostAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(Food), Encoding.UTF8, "application/json"));
            MessagingCenter.Send(this, "AddItem", Food);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}