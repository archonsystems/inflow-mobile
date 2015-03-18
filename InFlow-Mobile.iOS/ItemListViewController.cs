using System;
using System.Drawing;
using Cirrious.MvvmCross.Touch.Views;
using Foundation;
using InFlow_Mobile.iOS.Views;
using UIKit;

namespace InFlow_Mobile.iOS
{
    [FromStoryboard("ItemList")]
    public partial class ItemListViewController : BaseView
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public ItemListViewController(IntPtr handle)
            : base(handle)
        {
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();
            }
            catch (Exception ex)
            {
                
                throw;
            }
            
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}