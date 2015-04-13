using System.IO;
using System.Threading.Tasks;
using InFlow_Mobile.Core.ViewModels;
using SQLite.Net;
using Cirrious.CrossCore;

namespace InFlow_Mobile.Core
{
    public class InitializeDatabaseService : IInitializeDatabaseService
    {
		protected readonly IPlatform platform;

		public InitializeDatabaseService()
		{
			platform = Mvx.Resolve<IPlatform> ();
		}

        public async Task InitializeAsync()
        {
            var _db = new ItemDatabase(GetConnection);
            if (!DatabaseExists())
                await _db.InitializeAsync();
            App.Connection = _db;
        }

        private bool DatabaseExists()
        {
			return platform.DatabaseExists;
        }

        private string GetDatabasePath()
        {
			return platform.DatabasePath;
        }

        private SQLiteConnectionWithLock GetConnection()
        {
			return new SQLiteConnectionWithLock(platform.SQLitePlatform, new SQLiteConnectionString(GetDatabasePath(), false));
        }
    }
}