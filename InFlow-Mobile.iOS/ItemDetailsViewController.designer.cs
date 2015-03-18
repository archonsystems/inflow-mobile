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
	[Register ("ItemDetailsViewController")]
	partial class ItemDetailsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField DescriptionView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField NameView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SaveButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (DescriptionView != null) {
				DescriptionView.Dispose ();
				DescriptionView = null;
			}
			if (NameView != null) {
				NameView.Dispose ();
				NameView = null;
			}
			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
		}
	}
}
