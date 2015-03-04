using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Async;

namespace InFlow_Mobile.Core.ViewModels
{
    public class ItemDatabase : SQLiteAsyncConnection
    {
        public ItemDatabase(Func<SQLiteConnectionWithLock> sqliteConnectionFunc, TaskScheduler taskScheduler = null, TaskCreationOptions taskCreationOptions = TaskCreationOptions.None)
            : base(sqliteConnectionFunc, taskScheduler, taskCreationOptions)
        {
        }

        public async Task InitializeAsync()
        {
            await CreateTableAsync<Item>();
            await SeedAsync();
        }

        private async Task SeedAsync()
        {
            await InsertAsync(new Item { ProdId = 1, Name = "Watch", Description = "See the time, any time!" });
            await InsertAsync(new Item { ProdId = 2, Name = "Book", Description = "Learn something." });
        }

        public async Task<Item> LoadItem(int prodId)
        {
            return await Table<Item>().Where(x => x.ProdId == prodId).FirstOrDefaultAsync();
        }

        public async Task<List<Item>> GetAll()
        {
            return await Table<Item>().ToListAsync();
        }

        public async Task<List<Item>> SearchNameOrDescription(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAll();
            else
                return await Table<Item>().Where(x => x.Name.Contains(query) || x.Description.Contains(query)).ToListAsync();
        }

        public async Task InsertOrUpdateAsync(Item i)
        {
            await this.InsertOrReplaceAsync(i);
        }
    }
}