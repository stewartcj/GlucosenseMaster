using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlucoSmartMobile.Models;
using GlucoSmartMobile.Views;

namespace GlucoSmartMobile.Services
{
    public class GlucoseDataStore : IDataStore<GlucoseEntry>
    {
        readonly List<GlucoseEntry> items;

        public GlucoseDataStore()
        {
            items = MainPage.GlucEntries;
        }

        public async Task<bool> AddItemAsync(GlucoseEntry item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(GlucoseEntry item)
        {
            var oldItem = items.Where((GlucoseEntry arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((GlucoseEntry arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<GlucoseEntry> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<GlucoseEntry>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}