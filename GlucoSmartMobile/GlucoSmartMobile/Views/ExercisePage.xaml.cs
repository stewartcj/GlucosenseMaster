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
    public partial class ExercisePage : ContentPage
    {
        public List<Entry> entries = new List<Entry>();
        public ExerciseViewModel viewModel;

        public ExercisePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ExerciseViewModel();
            ExerciseChart.Chart = new LineChart();
        }

        private void PopulateEntries()
        {
            foreach (ExerciseEntry entry in viewModel.ExItems)
            {
                entries.Add(new Entry(entry.Minutes)
                {
                    Color = SKColor.Parse("#FF1493"),
                    ValueLabel = $"{entry.Minutes}",
                    Label = entry.Date.ToShortDateString()
                });
            }
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

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ExerciseEntryPage()));
        }

        private void ChartSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                ExerciseListView.IsVisible = false;
                PopulateEntries();
                ExerciseChart.Chart.Entries = entries;
                ExerciseLabel.IsVisible = true;
                ExerciseChart.IsVisible = true;
                ExerciseChart.Chart.LabelTextSize = 30;
            }
            else
            {
                ExerciseListView.IsVisible = true;
                ExerciseLabel.IsVisible = false;
                ExerciseChart.IsVisible = false;
            }
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

            viewModel.ExItems.Clear();
            if (viewModel.ExItems.Count == 0 && App.User != null)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}