using System;

using GlucoSmartMobile.Models;

namespace GlucoSmartMobile.ViewModels
{
    public class GlucoseDetailViewModel : BaseViewModel
    {
        public GlucoseEntry Glucose { get; set; }
        public GlucoseDetailViewModel(GlucoseEntry entry = null)
        {
            Title = entry?.Date.ToShortDateString() + entry?.Reading + entry?.Meal;
            Glucose = entry;
        }
    }
}
