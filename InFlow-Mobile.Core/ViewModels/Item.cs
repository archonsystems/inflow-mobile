using SQLite.Net.Attributes;

namespace InFlow_Mobile.Core.ViewModels
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ProdId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}