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
    public partial class FoodDetailPage : ContentPage
    {
        FoodDetailViewModel viewModel;

        public FoodDetailPage(FoodDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public FoodDetailPage()
        {
            InitializeComponent();

            var item = new FoodEntry
            {
                Id = 0,
                Name = "Apple",
                Calories = 100,
                Carbs = 50,
                Date = DateTime.Now,
                Username = App.User.UserName
            };

            viewModel = new FoodDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}