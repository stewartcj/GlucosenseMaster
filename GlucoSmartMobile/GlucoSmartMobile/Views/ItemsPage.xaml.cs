using System;
using System.ComponentModel;
using Xamarin.Forms;

using GlucoSmartMobile.Models;
using GlucoSmartMobile.ViewModels;

namespace GlucoSmartMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnGlucItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as GlucoseEntry;
            if (item == null)
                return;

            await Navigation.PushAsync(new GlucoseDetailPage(new GlucoseDetailViewModel(item)));

            // Manually deselect item.
            GlucoseListView.SelectedItem = null;
        }
        async void OnExItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ExerciseEntry;
            if (item == null)
                return;

            await Navigation.PushAsync(new ExerciseDetailPage(new ExerciseDetailViewModel(item)));

            // Manually deselect item.
            ExerciseListView.SelectedItem = null;
        }
        async void OnFoodItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as FoodEntry;
            if (item == null)
                return;

            await Navigation.PushAsync(new FoodDetailPage(new FoodDetailViewModel(item)));

            // Manually deselect item.
            FoodListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new GlucoseEntryPage()));
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

            if (App.User != null)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
            
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            App.User = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
            await Navigation.PopToRootAsync();
        }
    }
}