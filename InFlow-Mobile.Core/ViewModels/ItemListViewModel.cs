using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace InFlow_Mobile.Core.ViewModels
{
    /// <summary>
    /// Define the MainViewModel type.
    /// </summary>
    public class ItemListViewModel : BaseViewModel
    {
        /// <summary>
        /// Show the view model.
        /// </summary>
        public void Show()
        {
            this.ShowViewModel<ItemListViewModel>();        
        }

        public ItemListViewModel()
        {
            ExplicitSearch = ReactiveCommand.Create();

            (AddNewCommand = ReactiveCommand.Create()).Subscribe(_ => ShowViewModel<ItemDetailsViewModel>(new ItemDetailsViewNavigationParameters { }));
            (ShowDetailsCommand = ReactiveCommand.Create()).Subscribe(_ => ShowViewModel<ItemDetailsViewModel>(new ItemDetailsViewNavigationParameters { ProdId = SelectedProdId, ShouldLoad = true }));
            (SearchCommand = ReactiveCommand.Create(this.WhenAnyValue(x => x.Initialized))).Subscribe(async _ => await DoSearch());

            Observable.CombineLatest(
                this.WhenAnyValue(x => x.Initialized), 
                this.ObservableForProperty(x => x.SearchQuery).Throttle(TimeSpan.FromMilliseconds(500), RxApp.TaskpoolScheduler).Merge(ExplicitSearch).Select(x => true),
                (initialized, _) => initialized)
            .Where(x => x)
            .InvokeCommand(this, x => x.SearchCommand);
        }

        public ReactiveCommand<object> SearchCommand { get; set; }
        public ReactiveCommand<object> AddNewCommand { get; set; }
        public ReactiveCommand<object> ShowDetailsCommand { get; set; }
        public ReactiveCommand<object> ExplicitSearch { get; set; }

        private async Task DoSearch()
        {
            var results = await GetSearchResultsAsync();
            SearchResults.Clear();
            SearchResults.AddRange(results);
        }

        private Task<List<Item>> GetSearchResultsAsync()
        {
            return GetService<IItemRepositoryService>().SearchNameOrDescriptionAsync(SearchQuery);
        }

        private int _SelectedProdId;
        public int SelectedProdId { get { return this._SelectedProdId; } set { this.SetProperty(ref this._SelectedProdId, value, () => this.SelectedProdId); } }

        private string _SearchQuery = "";
        public string SearchQuery { get { return this._SearchQuery; } set { this.SetProperty(ref this._SearchQuery, value, () => this.SearchQuery); } }

        private ReactiveList<Item> _SearchResults = new ReactiveList<Item>();
        public ReactiveList<Item> SearchResults { get { return this._SearchResults; } set { this.SetProperty(ref this._SearchResults, value, () => this.SearchResults); } }       

    }
}
