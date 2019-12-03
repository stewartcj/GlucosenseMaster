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
    public partial class GlucosePage : ContentPage
    {

        public GlucoseViewModel viewModel;
        public List<Entry> PreBreak = new List<Entry>();
        public List<Entry> PostBreak = new List<Entry>();
        public List<Entry> PreLunch = new List<Entry>();
        public List<Entry> PostLunch = new List<Entry>();
        public List<Entry> PreDinner = new List<Entry>();
        public List<Entry> PostDinner = new List<Entry>();

        public GlucosePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new GlucoseViewModel();

            PreBreakfastChart.Chart = new LineChart();
            PostBreakfastChart.Chart = new LineChart();
            PreLunchChart.Chart = new LineChart();
            PostLunchChart.Chart = new LineChart();
            PreDinnerChart.Chart = new LineChart();
            PostDinnerChart.Chart = new LineChart();
        }

        private void PopulateEntries()
        {
            foreach(GlucoseEntry entry in viewModel.PreMealBreakfast)
            {
                PreBreak.Add(new Entry(entry.BloodSugar)
                {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = $"{entry.BloodSugar}",
                    Label = entry.Date.ToShortDateString()
                });
            }
            foreach (GlucoseEntry entry in viewModel.PostMealBreakfast)
            {
                PostBreak.Add(new Entry(entry.BloodSugar)
                {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = $"{entry.BloodSugar}",
                    Label = entry.Date.ToShortDateString()
                });
            }
            foreach (GlucoseEntry entry in viewModel.PreMealLunch)
            {
                PreLunch.Add(new Entry(entry.BloodSugar)
                {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = $"{entry.BloodSugar}",
                    Label = entry.Date.ToShortDateString()
                });
            }
            foreach (GlucoseEntry entry in viewModel.PostMealLunch)
            {
                PostLunch.Add(new Entry(entry.BloodSugar)
                {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = $"{entry.BloodSugar}",
                    Label = entry.Date.ToShortDateString()
                });
            }
            foreach (GlucoseEntry entry in viewModel.PreMealDinner)
            {
                PreDinner.Add(new Entry(entry.BloodSugar)
                {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = $"{entry.BloodSugar}",
                    Label = entry.Date.ToShortDateString()
                });
            }
            foreach (GlucoseEntry entry in viewModel.PostMealDinner)
            {
                PostDinner.Add(new Entry(entry.BloodSugar)
                {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = $"{entry.BloodSugar}",
                    Label = entry.Date.ToShortDateString()
                });
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as GlucoseEntry;
            if (item == null)
                return;

            await Navigation.PushAsync(new GlucoseDetailPage(new GlucoseDetailViewModel(item)));

            // Manually deselect item.
            GlucoseListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new GlucoseEntryPage()));
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

            viewModel.GlucItems.Clear();
            if (viewModel.GlucItems.Count == 0 && App.User != null)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }

        }

        private void ChartSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                GlucoseListView.IsVisible = false;
                PopulateEntries();

                PreBreakfastChart.Chart.Entries = PreBreak;
                PostBreakfastChart.Chart.Entries = PostBreak;
                PreLunchChart.Chart.Entries = PreLunch;
                PostLunchChart.Chart.Entries = PostLunch;
                PreDinnerChart.Chart.Entries = PreDinner;
                PostDinnerChart.Chart.Entries = PostDinner;

                PreBreakfastChart.Chart.LabelTextSize = 30;
                PostBreakfastChart.Chart.LabelTextSize = 30;
                PreLunchChart.Chart.LabelTextSize = 30;
                PostLunchChart.Chart.LabelTextSize = 30;
                PreDinnerChart.Chart.LabelTextSize = 30;
                PostDinnerChart.Chart.LabelTextSize = 30;

                PreB.IsVisible = true;
                PostB.IsVisible = true;
                PreL.IsVisible = true;
                PostL.IsVisible = true;
                PreD.IsVisible = true;
                PostD.IsVisible = true;

                PreBreakfastChart.IsVisible = true;
                PostBreakfastChart.IsVisible = true;
                PreLunchChart.IsVisible = true;
                PostLunchChart.IsVisible = true;
                PreDinnerChart.IsVisible = true;
                PostDinnerChart.IsVisible = true;
            }
            else
            {
                GlucoseListView.IsVisible = true;

                PreB.IsVisible = false;
                PostB.IsVisible = false;
                PreL.IsVisible = false;
                PostL.IsVisible = false;
                PreD.IsVisible = false;
                PostD.IsVisible = false;

                PreBreakfastChart.IsVisible = false;
                PostBreakfastChart.IsVisible = false;
                PreLunchChart.IsVisible = false;
                PostLunchChart.IsVisible = false;
                PreDinnerChart.IsVisible = false;
                PostDinnerChart.IsVisible = false;
            }
        }
    }
}