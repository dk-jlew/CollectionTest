using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollectionTest.Models;

namespace CollectionTest.Services
{

    public class MockDataStore : IDataStore<ItemGroup>
    {
        readonly IList<ItemGroup> itemGroups;

        public MockDataStore()
        {
            itemGroups = Enumerable.Range(0, 10).Select(g =>
            new ItemGroup($"GROUP {g}",
            Enumerable.Range(0, 10).Select(i => new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = $"Item {g}.{i}",
                Description = "This is an item description.",
                Padding = (int)(i * 1.1)
            }))).ToList();
        }

        public async Task<bool> AddItemAsync(ItemGroup item)
        {
            itemGroups.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemGroup item)
        {
            var oldItem = itemGroups.Where(arg => arg.Name == item.Name).FirstOrDefault();
            itemGroups.Remove(oldItem);
            itemGroups.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = itemGroups.Where(arg => arg.Name == id).FirstOrDefault();
            itemGroups.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemGroup> GetItemAsync(string id)
        {
            return await Task.FromResult(itemGroups.FirstOrDefault(s => s.Name == id));
        }

        public async Task<IEnumerable<ItemGroup>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(itemGroups);
        }
    }
}