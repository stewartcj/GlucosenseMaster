using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmartMobile.Models;
using GlucoSmartMobile.Views;

namespace GlucoSmartMobile.Services
{
    public class FoodDataStore : IDataStore<FoodEntry>
    {
        readonly List<FoodEntry> items;

        public FoodDataStore()
        {
            items = MainPage.FoodEntries;
        }

        public async Task<bool> AddItemAsync(FoodEntry item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(FoodEntry item)
        {
            var oldItem = items.Where((FoodEntry arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((FoodEntry arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<FoodEntry> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<FoodEntry>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}