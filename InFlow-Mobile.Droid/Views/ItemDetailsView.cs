using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.MvvmCross.Binding.BindingContext;
using InFlow_Mobile.Core.ViewModels;

namespace InFlow_Mobile.Droid.Views
{
    /// <summary>
    /// Defines the MainView type.
    /// </summary>
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

            //var set = this.CreateBindingSet<ItemDetailsView, ItemDetailsViewModel>();

            //set.Bind(FindViewById<EditText>(Resource.Id.NameText)).For(x => x.Text).To(vm => vm.Name);
            //set.Bind(FindViewById<EditText>(Resource.Id.DescriptionText)).For(x => x.Text).To(vm => vm.Description);

            //set.Apply();
        }
    }
}