using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GlucoSmartMobile.Models;
using GlucoSmartMobile.ViewModels;

namespace GlucoSmartMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ExerciseDetailPage : ContentPage
    {
        ExerciseDetailViewModel viewModel;

        public ExerciseDetailPage(ExerciseDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ExerciseDetailPage()
        {
            InitializeComponent();

            var item = new ExerciseEntry
            {
                Id = 0,
                Minutes = 40,
                Date = DateTime.Now,
                Exercise = ExerciseEntry.ExerciseType.Cardio,
                Intensity = ExerciseEntry.IntensityType.Low,
                Username = App.User.UserName
            };

            viewModel = new ExerciseDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}