// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Reactive.Linq;
using Android.Widget;
using Cirrious.MvvmCross.Binding.BindingContext;
using InFlow_Mobile.Core.ViewModels;
using ReactiveUI;

namespace InFlow_Mobile.Droid.Views
{
    using Android.App;
    using Android.OS;

    /// <summary>
    /// Defines the MainView type.
    /// </summary>
    [Activity(Label = "Item List")]
    public class ItemListView : BaseView
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="bundle">The bundle.</param>
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        
            this.SetContentView(Resource.Layout.ItemList);

            _listView = FindViewById<ListView>(Resource.Id.listView2);
            _searchView = FindViewById<SearchView>(Resource.Id.SearchView);

            Observable.FromEventPattern<SearchView.QueryTextChangeEventArgs>(h => _searchView.QueryTextChange += h, h => _searchView.QueryTextChange -= h)
                .Subscribe(e => ViewModel.SearchQuery = e.EventArgs.NewText);

            Observable.FromEventPattern<AdapterView.ItemClickEventArgs>(h => _listView.ItemClick += h, h => _listView.ItemClick -= h)
            .Subscribe(e =>
            {
                ViewModel.SelectedProdId = (int)e.EventArgs.Id;
                ViewModel.ShowDetailsCommand.Execute(null);
            });

            ViewModel.SearchResults.Changed
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(_ => _listView.Adapter = new ItemListAdapter(this, ViewModel.SearchResults.ToList()));

            await ViewModel.InitializeAsync();
        }

        protected async override void OnResume()
        {
            base.OnResume();

            await ViewModel.ExplicitSearch.ExecuteAsync(null);
        }

        protected new ItemListViewModel ViewModel { get { return (ItemListViewModel)base.ViewModel; } }

        private SearchView _searchView;
        private ListView _listView;
    }
}