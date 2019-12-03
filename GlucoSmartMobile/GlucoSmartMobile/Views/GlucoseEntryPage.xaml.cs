using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GlucoSmartMobile.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace GlucoSmartMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class GlucoseEntryPage : ContentPage
    {
        private List<string> Meals = new List<string>() { "Breakfast", "Lunch", "Dinner" };
        private List<string> Readings = new List<string>() { "PreMeal", "PostMeal" };
        private HttpClient client = new HttpClient();
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/Glucose";
        public GlucoseEntry Entry { get; set; }

        public GlucoseEntryPage()
        {
            InitializeComponent();
            Entry = new GlucoseEntry();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            int bloodSugar;
            Int32.TryParse(bloodSugarLabel.Text, out bloodSugar);

            Entry.Username = App.User.UserName;
            Entry.Date = DateTime.Now;
            Entry.BloodSugar = bloodSugar;
            Entry.Meal = (GlucoseEntry.MealType)Enum.Parse(typeof(GlucoseEntry.MealType), mealPicker.SelectedIndex.ToString());
            Entry.Reading = (GlucoseEntry.ReadingType)Enum.Parse(typeof(GlucoseEntry.ReadingType), readingPicker.SelectedIndex.ToString());


            await client.PostAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(Entry), Encoding.UTF8, "application/json"));
            MessagingCenter.Send(this, "AddItem", Entry);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            mealPicker.ItemsSource = Meals;
            readingPicker.ItemsSource = Readings;
        }
    }
}