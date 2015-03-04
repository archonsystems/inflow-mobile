using System.Collections.Generic;
using System.Threading.Tasks;
using InFlow_Mobile.Core.ViewModels;

namespace InFlow_Mobile.Core
{
    public interface IItemRepositoryService
    {
        Task<Item> LoadItemAsync(int prodId);
        Task<List<Item>> GetAllAsync();
        Task<List<Item>> SearchNameOrDescriptionAsync(string query);
        Task UpdateAsync(Item i);
        Task InsertAsync(Item i);
    }
}