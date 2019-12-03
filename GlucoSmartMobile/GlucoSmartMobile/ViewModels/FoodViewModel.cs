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
    public class FoodViewModel : BaseViewModel
    {
        public ObservableCollection<FoodEntry> FoodItems { get; set; }
        public Command LoadItemsCommand { get; set; }
        public FoodViewModel()
        {
            Title = "Food";
            FoodItems = new ObservableCollection<FoodEntry>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FoodItems.Clear();
                var foodItems = await FoodDataStore.GetItemsAsync(true);
                foreach (var item in foodItems)
                {
                    FoodItems.Add(item);
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
