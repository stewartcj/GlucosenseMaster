using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GlucoSmartMobile.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlucoSmartMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodSearchPage : ContentPage
    {
        public FoodSearchCriteria SearchCriteria { get; set; }
        public SearchQuery Query { get; set; }

        private HttpClient _client = new HttpClient();
        private string apiURL = "https://api.nal.usda.gov/fdc/v1/search?api_key=Waqn5RfjG3FvPYtChsljWbV6ISD2ajSyoWRLHDqb";
        public FoodSearchPage()
        {
            InitializeComponent();
            Query = new SearchQuery();
            SearchCriteria = new FoodSearchCriteria();
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchCriteria.generalSearchInput = FoodSearchBar.Text;
            SearchCriteria.pageNumber = 1;

            StringContent food = new StringContent(JsonConvert.SerializeObject(SearchCriteria).ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(apiURL, food);
            Query = JsonConvert.DeserializeObject<SearchQuery>(await response.Content.ReadAsStringAsync());

            FoodListView.ItemsSource = Query.Foods;

            NextButton.IsEnabled = true;
        }

        async void OnFoodItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as FoodAPI;
            if (item == null)
                return;

            await Navigation.PushModalAsync(new NavigationPage(new FoodEntryPage(item.FdcId)));


            // Manually deselect item.
            FoodListView.SelectedItem = null;
            await Navigation.PopAsync();
        }

        private async void PrevButton_Clicked(object sender, EventArgs e)
        {
            SearchCriteria.pageNumber -= 1;
            StringContent food = new StringContent(JsonConvert.SerializeObject(SearchCriteria).ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(apiURL, food);
            Query = JsonConvert.DeserializeObject<SearchQuery>(await response.Content.ReadAsStringAsync());

            FoodListView.ItemsSource = Query.Foods;

            if (Query.CurrentPage > 1)
            {
                PrevButton.IsEnabled = true;
            }
            else
            {
                PrevButton.IsEnabled = false;
            }
            if (Query.CurrentPage == Query.TotalPages)
            {
                NextButton.IsEnabled = false;
            }
            else
            {
                NextButton.IsEnabled = true;
            }
        }

        private async void NextButton_Clicked(object sender, EventArgs e)
        {
            SearchCriteria.pageNumber += 1;
            StringContent food = new StringContent(JsonConvert.SerializeObject(SearchCriteria).ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(apiURL, food);
            Query = JsonConvert.DeserializeObject<SearchQuery>(await response.Content.ReadAsStringAsync());

            FoodListView.ItemsSource = Query.Foods;

            if (Query.CurrentPage > 1)
            {
                PrevButton.IsEnabled = true;
            }
            if (Query.CurrentPage == Query.TotalPages)
            {
                NextButton.IsEnabled = false;
            }
            else
            {
                NextButton.IsEnabled = true;
            }
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

            PrevButton.IsEnabled = false;
            NextButton.IsEnabled = false;
        }

        private async void DoneButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}