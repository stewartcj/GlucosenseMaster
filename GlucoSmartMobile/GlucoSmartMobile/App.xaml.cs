using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GlucoSmartMobile.Views;
using GlucoSmartMobile.Models;
using System.Collections.Generic;
using GlucoSmartMobile.Services;

namespace GlucoSmartMobile
{
    public partial class App : Application
    {
        public static ApplicationUser User { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public App(ApplicationUser user)
        {

        }

        private void Login()
        {
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            
        }
    }
}
