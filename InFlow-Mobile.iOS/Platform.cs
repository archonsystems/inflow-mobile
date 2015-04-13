using System;
using System.IO;
using InFlow_Mobile.Core;
using SQLite.Net.Platform.XamarinIOS;
using SQLite.Net.Interop;

namespace InFlow_Mobile.iOS
{
    class Platform : IPlatform
    {
		const string sqliteFilename = "inflow.mobile.db3";

		public bool DatabaseExists { get { return File.Exists(DatabasePath); } }

		public ISQLitePlatform SQLitePlatform  { get { return new SQLitePlatformIOS (); } }

        public string DatabasePath
        {
            get
            {
                // we need to put in /Library/ since iOS5.1 to meet Apple's iCloud terms (they don't want non-user-generated data in Documents)
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
    
                return Path.Combine(libraryPath, sqliteFilename);
            }
        }
    }
}