using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GlucoSmartMobile.Models;

namespace GlucoSmartMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public static List<GlucoseEntry> GlucEntries;
        public static List<ExerciseEntry> ExEntries;
        public static List<FoodEntry> FoodEntries;

        public MainPage(List<GlucoseEntry> glucEntries, List<ExerciseEntry> exEntries, List<FoodEntry> foodEntries)
        {
            GlucEntries = glucEntries;
            FoodEntries = foodEntries;
            ExEntries = exEntries;

            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;

                    case (int)MenuItemType.Glucose:
                        MenuPages.Add(id, new NavigationPage(new GlucosePage()));
                        break;

                    case (int)MenuItemType.Exercise:
                        MenuPages.Add(id, new NavigationPage(new ExercisePage()));
                        break;

                    case (int)MenuItemType.Food:
                        MenuPages.Add(id, new NavigationPage(new FoodPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}