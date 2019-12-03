using System;

using GlucoSmartMobile.Models;

namespace GlucoSmartMobile.ViewModels
{
    public class ExerciseDetailViewModel : BaseViewModel
    {
        public ExerciseEntry Exercise { get; set; }
        public ExerciseDetailViewModel(ExerciseEntry entry = null)
        {
            Title = entry?.Date.ToShortDateString();
            Exercise = entry;
        }
    }
}
