using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Binding.BindingContext;
using InFlow_Mobile.Core.ViewModels;

namespace InFlow_Mobile.Droid.Views
{
    [Activity(Label = "Item Details")]
    public class ItemDetailsView : BaseView
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.ItemDetails);
        }
    }
}