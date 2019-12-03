using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using GlucoSmartMobile.Models;
using GlucoSmartMobile.Views;
using System.Collections.Generic;

namespace GlucoSmartMobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<GlucoseEntry> GlucItems { get; set; }
        public ObservableCollection<ExerciseEntry> ExItems { get; set; }
        public ObservableCollection<FoodEntry> FoodItems { get; set; }

        public ObservableCollection<GlucoseEntry> RecentGlucItems { get; set; }
        public ObservableCollection<ExerciseEntry> RecentExItems { get; set; }
        public ObservableCollection<FoodEntry> RecentFoodItems { get; set; }

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Home";
            GlucItems = new ObservableCollection<GlucoseEntry>();
            RecentGlucItems = new ObservableCollection<GlucoseEntry>();
            ExItems = new ObservableCollection<ExerciseEntry>();
            RecentExItems = new ObservableCollection<ExerciseEntry>();
            FoodItems = new ObservableCollection<FoodEntry>();
            RecentFoodItems = new ObservableCollection<FoodEntry>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<GlucoseEntryPage, GlucoseEntry>(this, "AddItem", async (obj, item) =>
            {
                var newGlucItem = item as GlucoseEntry;
                GlucItems.Add(newGlucItem);
                await GlucDataStore.AddItemAsync(newGlucItem);
            });

            MessagingCenter.Subscribe<ExerciseEntryPage, ExerciseEntry>(this, "AddItem", async (obj, item) =>
            {
                var newExItem = item as ExerciseEntry;
                ExItems.Add(newExItem);
                await ExDataStore.AddItemAsync(newExItem);
            });

            MessagingCenter.Subscribe<FoodEntryPage, FoodEntry>(this, "AddItem", async (obj, item) =>
            {
                var newFoodItem = item as FoodEntry;
                FoodItems.Add(newFoodItem);
                await FoodDataStore.AddItemAsync(newFoodItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                GlucItems.Clear();
                RecentGlucItems.Clear();
                var glucItems = await GlucDataStore.GetItemsAsync(true);
                foreach (var item in glucItems)
                {
                    GlucItems.Add(item);
                }

                if (GlucItems.Count > 10)
                {
                    for (int i = GlucItems.Count - 10; i < GlucItems.Count; i++)
                    {
                        RecentGlucItems.Add(GlucItems[i]);
                    }
                }
                else
                {
                    foreach (GlucoseEntry entry in GlucItems)
                    {
                        RecentGlucItems.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                ExItems.Clear();
                RecentExItems.Clear();
                var exItems = await ExDataStore.GetItemsAsync(true);
                foreach (var item in exItems)
                {
                    ExItems.Add(item);
                }

                if (ExItems.Count > 10)
                {
                    for (int i = ExItems.Count - 10; i < ExItems.Count; i++)
                    {
                        RecentExItems.Add(ExItems[i]);
                    }
                }
                else
                {
                    foreach (ExerciseEntry entry in ExItems)
                    {
                        RecentExItems.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            try
            {
                FoodItems.Clear();
                RecentFoodItems.Clear();
                var foodItems = await FoodDataStore.GetItemsAsync(true);
                foreach (var item in foodItems)
                {
                    FoodItems.Add(item);
                }

                if (FoodItems.Count > 10)
                {
                    for (int i = FoodItems.Count - 10; i < FoodItems.Count; i++)
                    {
                        RecentFoodItems.Add(FoodItems[i]);
                    }
                }
                else
                {
                    foreach (FoodEntry entry in FoodItems)
                    {
                        RecentFoodItems.Add(entry);
                    }
                }
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
    }
}