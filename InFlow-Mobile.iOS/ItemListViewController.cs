using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Bindings;
using Cirrious.MvvmCross.Touch.Views;
using InFlow_Mobile.Core.ViewModels;
using InFlow_Mobile.iOS.Views;
using ReactiveUI;
using UIKit;

namespace InFlow_Mobile.iOS
{
    [FromStoryboard("ItemList")]
    public partial class ItemListViewController : BaseView
    {
        public ItemListViewController(IntPtr handle)
            : base(handle)
        {
        }

        private ItemListTableViewSource<Item> _viewSource;

        protected new ItemListViewModel ViewModel { get { return (ItemListViewModel)base.ViewModel; } }        

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            _viewSource = new ItemListTableViewSource<Item>(ItemListTableView);
            ItemListTableView.Source = _viewSource;

            ViewModel.SearchResults.Changed
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(items => _viewSource.ItemsSource = ViewModel.SearchResults);

            Observable.FromEventPattern<UISearchBarTextChangedEventArgs>(h => SearchBar.TextChanged += h, h => SearchBar.TextChanged -= h)
                .Subscribe(e => ViewModel.SearchQuery = e.EventArgs.SearchText);

            _viewSource.ItemClicked.Subscribe(item => 
            {
                ViewModel.SelectedProdId = item.ProdId;
                ViewModel.ShowDetailsCommand.Execute(null);
            });

            var set = this.CreateBindingSet<ItemListViewController, ItemListViewModel>();
            set.Bind(AddNewButton).To(vm => vm.AddNewCommand);
            set.Apply();

            await ViewModel.InitializeAsync();
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            await ViewModel.ExplicitSearch.ExecuteAsync(null);
        }

    }
}