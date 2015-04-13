using System;

namespace InFlow_Mobile.Core
{
	public interface IPlatform
	{
		string DatabasePath { get; }
		bool DatabaseExists { get; }
		SQLite.Net.Interop.ISQLitePlatform SQLitePlatform { get; }
	}
}

