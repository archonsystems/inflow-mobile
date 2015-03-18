
using System;
using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Foundation;
using InFlow_Mobile.Core.ViewModels;
using InFlow_Mobile.iOS.Views;
using ReactiveUI;
using UIKit;

namespace InFlow_Mobile.iOS
{
    [FromStoryboard("ItemDetails")]
    public partial class ItemDetailsViewController : BaseView
    {
        public ItemDetailsViewController(IntPtr handle)
            : base(handle)
        {
        }

        protected new ItemDetailsViewModel ViewModel { get { return (ItemDetailsViewModel)base.ViewModel; } }        

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ItemDetailsViewController, ItemDetailsViewModel>();
            set.Bind(NameView).To(vm => vm.Name);
            set.Bind(DescriptionView).To(vm => vm.Description);
            set.Bind(SaveButton).To(vm => vm.SaveCommand);
            set.Apply();
        }

    }
}