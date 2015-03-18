// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace InFlow_Mobile.iOS
{
	[Register ("ItemListViewController")]
	partial class ItemListViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton AddNewButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView ItemListTableView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISearchBar SearchBar { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (AddNewButton != null) {
				AddNewButton.Dispose ();
				AddNewButton = null;
			}
			if (ItemListTableView != null) {
				ItemListTableView.Dispose ();
				ItemListTableView = null;
			}
			if (SearchBar != null) {
				SearchBar.Dispose ();
				SearchBar = null;
			}
		}
	}
}
