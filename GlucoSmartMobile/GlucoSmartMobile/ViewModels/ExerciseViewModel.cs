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
    public class ExerciseViewModel : BaseViewModel
    {
        public ObservableCollection<ExerciseEntry> ExItems { get; set; }
        public Command LoadItemsCommand { get; set; }
        public ExerciseViewModel()
        {
            Title = "Exercise";
            ExItems = new ObservableCollection<ExerciseEntry>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ExItems.Clear();
                var exItems = await ExDataStore.GetItemsAsync(true);
                foreach (var item in exItems)
                {
                    ExItems.Add(item);
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
