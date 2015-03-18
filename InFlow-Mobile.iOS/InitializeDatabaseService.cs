using System.IO;
using System.Threading.Tasks;
using InFlow_Mobile.Core;
using InFlow_Mobile.Core.ViewModels;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

namespace InFlow_Mobile.iOS
{
    public class InitializeDatabaseService : IInitializeService
    {
        public async Task InitializeAsync()
        {
            var _db = new ItemDatabase(GetConnection);
            if (!DatabaseExists())
                await _db.InitializeAsync();
            App.Connection = _db;
        }

        private static bool DatabaseExists()
        {
            return File.Exists(GetDatabasePath());
        }

        private static string GetDatabasePath()
        {
            return System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "inflow.mobile.db3");
        }

        private static SQLiteConnectionWithLock GetConnection()
        {
            return new SQLiteConnectionWithLock(new SQLitePlatformIOS(), new SQLiteConnectionString(GetDatabasePath(), false));
        }
    }
}