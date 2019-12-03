using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmartMobile.Models;
using GlucoSmartMobile.Views;

namespace GlucoSmartMobile.Services
{
    public class ExerciseDataStore : IDataStore<ExerciseEntry>
    {
        readonly List<ExerciseEntry> items;

        public ExerciseDataStore()
        {
            items = MainPage.ExEntries;
        }

        public async Task<bool> AddItemAsync(ExerciseEntry item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ExerciseEntry item)
        {
            var oldItem = items.Where((ExerciseEntry arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((ExerciseEntry arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ExerciseEntry> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ExerciseEntry>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}