using GlucoSmartMobile.Models;
using GlucoSmartMobile.ViewModels;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Entry = Microcharts.Entry;

namespace GlucoSmartMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodPage : ContentPage
    {
        public FoodViewModel viewModel;
        private List<Entry> carbs = new List<Entry>();
        private List<Entry> calories = new List<Entry>();
        public FoodPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new FoodViewModel();

            CarbChart.Chart = new LineChart();
            CalorieChart.Chart = new LineChart();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodSearchPage());
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

        protected override void OnAppearing()
        {

            base.OnAppearing();

            viewModel.FoodItems.Clear();
            if (viewModel.FoodItems.Count == 0 && App.User != null)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }

        private void ChartSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                FoodListView.IsVisible = false;
                PopulateEntries();
                CarbChart.Chart.Entries = carbs;
                CarbLabel.IsVisible = true;
                CarbChart.IsVisible = true;
                CarbChart.Chart.LabelTextSize = 30;

                CalorieChart.Chart.Entries = calories;
                CalorieLabel.IsVisible = true;
                CalorieChart.IsVisible = true;
                CalorieChart.Chart.LabelTextSize = 30;
            }
            else
            {
                FoodListView.IsVisible = true;
                CarbLabel.IsVisible = false;
                CarbChart.IsVisible = false;
                CalorieLabel.IsVisible = false;
                CalorieChart.IsVisible = false;
            }
        }

        private void PopulateEntries()
        {
            int carbSum = 0;
            int calorieSum = 0;

            for (int i = 0; i < viewModel.FoodItems.Count; i++)
            {
                if (i != viewModel.FoodItems.Count - 1)
                {
                    if (viewModel.FoodItems[i].Date.ToShortDateString().Equals(viewModel.FoodItems[i + 1].Date.ToShortDateString()))
                    {
                        carbSum += viewModel.FoodItems[i].Carbs;
                        calorieSum += viewModel.FoodItems[i].Calories;
                    }
                    else
                    {
                        carbSum += viewModel.FoodItems[i].Carbs;
                        calorieSum += viewModel.FoodItems[i].Calories;

                        carbs.Add(new Entry(carbSum)
                        {
                            Color = SKColor.Parse("#FF1493"),
                            ValueLabel = $"{carbSum}",
                            Label = viewModel.FoodItems[i].Date.ToShortDateString()
                        });
                        calories.Add(new Entry(calorieSum)
                        {
                            Color = SKColor.Parse("#FF1493"),
                            ValueLabel = $"{calorieSum}",
                            Label = viewModel.FoodItems[i].Date.ToShortDateString()
                        });

                        carbSum = 0;
                        calorieSum = 0;
                    }
                }
                else
                {
                    carbSum += viewModel.FoodItems[i].Carbs;
                    calorieSum += viewModel.FoodItems[i].Calories;

                    carbs.Add(new Entry(carbSum)
                    {
                        Color = SKColor.Parse("#FF1493"),
                        ValueLabel = $"{carbSum}",
                        Label = viewModel.FoodItems[i].Date.ToShortDateString()
                    });
                    calories.Add(new Entry(calorieSum)
                    {
                        Color = SKColor.Parse("#FF1493"),
                        ValueLabel = $"{calorieSum}",
                        Label = viewModel.FoodItems[i].Date.ToShortDateString()
                    });

                    carbSum = 0;
                    calorieSum = 0;
                }
            }
        }
    }
}