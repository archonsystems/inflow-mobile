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
        private ItemListTableViewSource<Item> _viewSource;

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public ItemListViewController(IntPtr handle)
            : base(handle)
        {
        }

        protected new ItemListViewModel ViewModel { get { return (ItemListViewModel)base.ViewModel; } }        

        #region View lifecycle

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            _viewSource = new ItemListTableViewSource<Item>(ItemListTableView);
            ItemListTableView.Source = _viewSource;

            ViewModel.SearchResults.Changed
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(items => _viewSource.ItemsSource = ViewModel.SearchResults);

            //var set = this.CreateBindingSet<ItemListViewController, ItemListViewModel>();
            //set.Bind(viewSource).To(vm => vm.SearchResults);
            //set.Apply();

            Observable.FromEventPattern<UISearchBarTextChangedEventArgs>(h => SearchBar.TextChanged += h, h => SearchBar.TextChanged -= h)
                .Subscribe(e => ViewModel.SearchQuery = e.EventArgs.SearchText);

            _viewSource.ItemClicked.Subscribe(item => 
            {
                ViewModel.SelectedProdId = item.ProdId;
                ViewModel.ShowDetailsCommand.Execute(null);
            });

            await ViewModel.InitializeAsync();

            //Observable.FromEventPattern<AdapterView.ItemClickEventArgs>(h => _listView.ItemClick += h, h => _listView.ItemClick -= h)
            //.Subscribe(e =>
            //{
            //    ViewModel.SelectedProdId = (int)e.EventArgs.Id;
            //    ViewModel.ShowDetailsCommand.Execute(null);
            //});

            //await ViewModel.InitializeAsync();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            await ViewModel.ExplicitSearch.ExecuteAsync(null);
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