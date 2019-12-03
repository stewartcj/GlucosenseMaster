using System;

using GlucoSmartMobile.Models;

namespace GlucoSmartMobile.ViewModels
{
    public class FoodDetailViewModel : BaseViewModel
    {
        public FoodEntry Food { get; set; }
        public FoodDetailViewModel(FoodEntry entry = null)
        {
            Title = entry?.Name;
            Food = entry;
        }
    }
}
