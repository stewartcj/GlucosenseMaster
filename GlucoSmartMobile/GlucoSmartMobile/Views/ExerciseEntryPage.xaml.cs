using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GlucoSmartMobile.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using GlucoSmartMobile.Services;

namespace GlucoSmartMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ExerciseEntryPage : ContentPage
    {
        public ExerciseEntry Exercise { get; set; }
        private HttpClient client = new HttpClient();
        private string apiUrl = $"https://glucosmartapi.azurewebsites.net/api/Exercise";

        public ExerciseEntryPage()
        {
            InitializeComponent();
            Exercise = new ExerciseEntry();

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            int minutes;
            Int32.TryParse(MinuteLabel.Text, out minutes);

            Exercise.Username = App.User.UserName;
            Exercise.Date = DateTime.Now;
            Exercise.Minutes = minutes;
            Exercise.Intensity = (ExerciseEntry.IntensityType)Enum.Parse(typeof(ExerciseEntry.IntensityType), IntensityPicker.SelectedIndex.ToString());
            Exercise.Exercise = (ExerciseEntry.ExerciseType)Enum.Parse(typeof(ExerciseEntry.ExerciseType), ExercisePicker.SelectedIndex.ToString());


            await client.PostAsync(apiUrl, new StringContent(JsonConvert.SerializeObject(Exercise), Encoding.UTF8, "application/json"));
            MessagingCenter.Send(this, "AddItem", Exercise);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
            
    }
}