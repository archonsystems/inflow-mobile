using System;
using SQLite.Net.Platform.XamarinAndroid;
using InFlow_Mobile.Core;
using SQLite.Net.Interop;
using System.IO;

namespace InFlow_Mobile.Droid
{
	class Platform : IPlatform
	{
		const string sqliteFilename = "inflow.mobile.db3";

		public bool DatabaseExists { get { return File.Exists(DatabasePath); } }
		public ISQLitePlatform SQLitePlatform  { get { return new SQLitePlatformAndroid (); } }
		public string DatabasePath { get { return Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), sqliteFilename); } }
	}
}

