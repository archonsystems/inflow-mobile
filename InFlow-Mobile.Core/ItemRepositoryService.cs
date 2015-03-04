using System.Collections.Generic;
using System.Threading.Tasks;
using InFlow_Mobile.Core.ViewModels;

namespace InFlow_Mobile.Core
{
    public class ItemRepositoryService : IItemRepositoryService
    {
        public async Task<Item> LoadItemAsync(int prodId)
        {
            return await App.Connection.Table<Item>().Where(x => x.ProdId == prodId).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await App.Connection.Table<Item>().ToListAsync();
        }

        public async Task<List<Item>> SearchNameOrDescriptionAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAllAsync();
            else
                return await App.Connection.Table<Item>().Where(x => x.Name.Contains(query) || x.Description.Contains(query)).ToListAsync();
        }

        public async Task UpdateAsync(Item i)
        {
            await App.Connection.InsertOrReplaceAsync(i);
        }

        public async Task InsertAsync(Item i)
        {
            await App.Connection.InsertAsync(i);
        }

    }
}