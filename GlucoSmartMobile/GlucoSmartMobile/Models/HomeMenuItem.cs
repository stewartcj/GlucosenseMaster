using System;
using System.Collections.Generic;
using System.Text;

namespace GlucoSmartMobile.Models
{
    public enum MenuItemType
    {
        Home,
        Glucose,
        Food,
        Exercise
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
