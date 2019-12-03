using GlucoSmartMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GlucoSmartMobile.ViewModels
{
    public class GlucoseViewModel : BaseViewModel
    {
        public ObservableCollection<GlucoseEntry> GlucItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public List<GlucoseEntry> PreMealBreakfast { get; set; }
        public List<GlucoseEntry> PostMealBreakfast { get; set; }
        public List<GlucoseEntry> PreMealLunch { get; set; }
        public List<GlucoseEntry> PostMealLunch { get; set; }
        public List<GlucoseEntry> PreMealDinner { get; set; }
        public List<GlucoseEntry> PostMealDinner { get; set; }
        public GlucoseViewModel()
        {
            Title = "Glucose";
            GlucItems = new ObservableCollection<GlucoseEntry>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            PreMealBreakfast = new List<GlucoseEntry>();
            PostMealBreakfast = new List<GlucoseEntry>();
            PreMealLunch = new List<GlucoseEntry>();
            PostMealLunch = new List<GlucoseEntry>();
            PreMealDinner = new List<GlucoseEntry>();
            PostMealDinner = new List<GlucoseEntry>();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                GlucItems.Clear();
                var glucItems = await GlucDataStore.GetItemsAsync(true);
                foreach (var item in glucItems)
                {
                    GlucItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                PopulateEntries();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void PopulateEntries()
        {
            PreMealBreakfast.Clear();
            PostMealBreakfast.Clear();
            PreMealLunch.Clear();
            PostMealLunch.Clear();
            PreMealDinner.Clear();
            PostMealDinner.Clear();

            foreach (GlucoseEntry entry in GlucItems)
            {
                if (entry.Meal == GlucoseEntry.MealType.Breakfast && entry.Reading == GlucoseEntry.ReadingType.PreMeal)
                {
                    PreMealBreakfast.Add(entry);
                }
                else if (entry.Meal == GlucoseEntry.MealType.Breakfast && entry.Reading == GlucoseEntry.ReadingType.PostMeal)
                {
                    PostMealBreakfast.Add(entry);
                }
                else if (entry.Meal == GlucoseEntry.MealType.Lunch && entry.Reading == GlucoseEntry.ReadingType.PreMeal)
                {
                    PreMealLunch.Add(entry);
                }
                else if (entry.Meal == GlucoseEntry.MealType.Lunch && entry.Reading == GlucoseEntry.ReadingType.PostMeal)
                {
                    PostMealLunch.Add(entry);
                }
                else if (entry.Meal == GlucoseEntry.MealType.Dinner && entry.Reading == GlucoseEntry.ReadingType.PreMeal)
                {
                    PreMealDinner.Add(entry);
                }
                if (entry.Meal == GlucoseEntry.MealType.Dinner && entry.Reading == GlucoseEntry.ReadingType.PostMeal)
                {
                    PostMealDinner.Add(entry);
                }
            }
        }
    }
}
