using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GlucoSmartMobile.Models;
using GlucoSmartMobile.ViewModels;

namespace GlucoSmartMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class GlucoseDetailPage : ContentPage
    {
        GlucoseDetailViewModel viewModel;

        public GlucoseDetailPage(GlucoseDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public GlucoseDetailPage()
        {
            InitializeComponent();

            var item = new GlucoseEntry
            {
                BloodSugar = 40,
                Date = DateTime.Now,
                Meal = GlucoseEntry.MealType.Breakfast,
                Reading = GlucoseEntry.ReadingType.PreMeal,
                Username = App.User.UserName
            };

            viewModel = new GlucoseDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}